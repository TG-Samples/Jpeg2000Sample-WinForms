using System;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.WinForms;
using System.IO;

namespace ThinkGeo.MapSuite.Samples
{
	public partial class MainForm : Form
	{
		public MainForm ()
		{
			InitializeComponent ();
		}

		private void MainForm_Load (object sender, EventArgs e)
		{
			winformsMap1.MapUnit = GeographyUnit.Meter;

			LayerOverlay overlay = new LayerOverlay ();


			//To resolve issue that we cannot run the executable by double click it on linux, we need to find out the absolute path by reflection.
			string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
			string jpeg2000LayerFileName = Path.GetFullPath (Path.Combine (baseDirectory, "../../App_Data/World.jp2"));

			Jpeg2000RasterLayer jpeg2000RasterLayer = new Jpeg2000RasterLayer (jpeg2000LayerFileName);
			overlay.Layers.Add (jpeg2000RasterLayer);

			winformsMap1.Overlays.Add (overlay);

			jpeg2000RasterLayer.Open ();
			winformsMap1.CurrentExtent = jpeg2000RasterLayer.GetBoundingBox ();

			winformsMap1.Refresh ();
		}
	}
}