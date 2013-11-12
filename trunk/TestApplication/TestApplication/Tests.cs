﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="MapWindow Open Source GIS Community">
//   MapWindow Open Source GIS Community
// </copyright>
// <summary>
//   Static class to hold the tests methods
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TestApplication
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Threading;
  using System.Windows.Forms;

  using MapWinGIS;

  /// <summary>Static class to hold the tests methods</summary>
  internal static class Tests
  {

    /// <summary>
    /// Gets or sets Map.
    /// </summary>
    internal static AxMapWinGIS.AxMap MyAxMap { get; set; }

    /// <summary>Select a text file using an OpenFileDialog</summary>
    /// <param name="textBox">
    /// The text box.
    /// </param>
    /// <param name="title">
    /// The title.
    /// </param>
    internal static void SelectTextfile(Control textBox, string title)
    {
      using (var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = @"Text file (*.txt)|*.txt|All files|*.*",
        Multiselect = false,
        SupportMultiDottedExtensions = true,
        Title = title
      })
      {
        if (textBox.Text != string.Empty)
        {
          var folder = Path.GetDirectoryName(textBox.Text);
          if (folder != null)
          {
            if (Directory.Exists(folder))
            {
              ofd.InitialDirectory = folder;
            }
          }
        }

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          textBox.Text = ofd.FileName;
        }
      }
    }

    /// <summary>
    /// Run shapefile open tests
    /// </summary>
    /// <param name="textfileLocation">
    /// The textfile location.
    /// </param>
    /// <param name="theForm">
    /// The form with the callback implementation.
    /// </param>
    /// <exception cref="FileNotFoundException">
    /// When the file is not found
    /// </exception>
    internal static void RunShapefileTest(string textfileLocation, Form1 theForm)
    {
      // Open text file:
      if (!File.Exists(textfileLocation))
      {
        throw new FileNotFoundException("Cannot find text file.", textfileLocation);
      }

      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The shapefile open tests have started.", Environment.NewLine));

      // Open file, read line by line, skip lines starting with #
      var lines = File.ReadAllLines(textfileLocation);
      foreach (var line in lines.Where(line => !line.StartsWith("#") && line.Length != 0))
      {
        try
        {
          // Open shapefile:
          Fileformats.OpenShapefileAsLayer(line, theForm, true);

          // Wait a second to show something:
          Application.DoEvents();
          Thread.Sleep(1000);
        }
        catch (System.Runtime.InteropServices.SEHException sehException)
        {
          theForm.Error(string.Empty, "SEHException in RunShapefileTest: " + sehException.Message);
        }
      }

      theForm.Progress(string.Empty, 100, "The shapefile open tests have finished.");
    }
  
    /// <summary>
    /// Run image open tests
    /// </summary>
    /// <param name="textfileLocation">
    /// The textfile location.
    /// </param>
    /// <param name="theForm">
    /// The form with the callback implementation.
    /// </param>
    /// <exception cref="FileNotFoundException">
    /// When the file is not found
    /// </exception>
    internal static void RunImagefileTest(string textfileLocation, Form1 theForm)
    {
      // Open text file:
      if (!File.Exists(textfileLocation))
      {
        throw new FileNotFoundException("Cannot find text file.", textfileLocation);
      }

      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The image open tests have started.", Environment.NewLine));

      // Open file, read line by line, skip lines starting with #
      var lines = File.ReadAllLines(textfileLocation);
      foreach (var line in lines.Where(line => !line.StartsWith("#") && line.Length != 0))
      {
        try
        {
          // Open image:
          Fileformats.OpenImageAsLayer(line, theForm, true);

          // Wait a second to show something:
          Application.DoEvents();
          Thread.Sleep(1000);
        }
        catch (System.Runtime.InteropServices.SEHException sehException)
        {
          theForm.Error(string.Empty, "SEHException in RunImagefileTest: " + sehException.Message);
        }
      }

      theForm.Progress(string.Empty, 100, "The image open tests have finished.");
    }

    /// <summary>
    /// Run grid open tests
    /// </summary>
    /// <param name="textfileLocation">
    /// The textfile location.
    /// </param>
    /// <param name="theForm">
    /// The form with the callback implementation.
    /// </param>
    /// <exception cref="FileNotFoundException">
    /// When the file is not found
    /// </exception>
    internal static void RunGridfileTest(string textfileLocation, Form1 theForm)
    {
      // Open text file:
      if (!File.Exists(textfileLocation))
      {
        throw new FileNotFoundException("Cannot find text file.", textfileLocation);
      }

      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The grid open tests have started.", Environment.NewLine));

      // Open file, read line by line, skip lines starting with #
      var lines = File.ReadAllLines(textfileLocation);
      foreach (var line in lines.Where(line => !line.StartsWith("#") && line.Length != 0))
      {
        try
        {
          // Open image:
          Fileformats.OpenGridAsLayer(line, theForm, true);

          // Wait a second to show something:
          Application.DoEvents();
          Thread.Sleep(1000);
        }
        catch (System.Runtime.InteropServices.SEHException sehException)
        {
          theForm.Error(string.Empty, "SEHException in RunGridfileTest: " + sehException.Message);
        }
      }

      theForm.Progress(string.Empty, 100, "The grid open tests have finished.");
    }

    /// <summary>Select a grid file</summary>
    /// <param name="textBox">
    /// The text box.
    /// </param>
    /// <param name="title">
    /// The title.
    /// </param>
    internal static void SelectGridfile(TextBox textBox, string title)
    {
      var grd = new MapWinGIS.Grid();

      using (var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = grd.CdlgFilter,
        Multiselect = false,
        SupportMultiDottedExtensions = true,
        Title = title
      })
      {
        if (textBox.Text != string.Empty)
        {
          var folder = Path.GetDirectoryName(textBox.Text);
          if (folder != null)
          {
            if (Directory.Exists(folder))
            {
              ofd.InitialDirectory = folder;
            }
          }
        }

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          textBox.Text = ofd.FileName;
        }
      }
    }

    /// <summary>Select a shapefile</summary>
    /// <param name="textBox">
    /// The text box.
    /// </param>
    /// <param name="title">
    /// The title.
    /// </param>
    internal static void SelectShapefile(TextBox textBox, string title)
    {
      using (var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = @"Shapefiles|*.shp",
        Multiselect = false,
        SupportMultiDottedExtensions = true,
        Title = title
      })
      {
        if (textBox.Text != string.Empty)
        {
          var folder = Path.GetDirectoryName(textBox.Text);
          if (folder != null)
          {
            if (Directory.Exists(folder))
            {
              ofd.InitialDirectory = folder;
            }
          }
        }

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          textBox.Text = ofd.FileName;
        }
      }
    }

    /// <summary>Run the Clip grid by polygon test</summary>
    /// <param name="gridFilename">
    /// The grid filename.
    /// </param>
    /// <param name="shapefilename">
    /// The shapefilename.
    /// </param>
    /// <param name="theForm">
    /// The form.
    /// </param>
    internal static void RunClipGridByPolygonTest(string gridFilename, string shapefilename, Form1 theForm)
    {
      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The Clip grid by polygon test has started.", Environment.NewLine));

      try
      {
        // Check inputs:
        if (gridFilename == string.Empty || shapefilename == string.Empty)
        {
          theForm.Error(string.Empty, "Input parameters are wrong");
          return;
        }

        var folder = Path.GetDirectoryName(gridFilename);
        if (folder == null)
        {
          theForm.Error(string.Empty, "Input parameters are wrong");
          return;
        }

        if (!Directory.Exists(folder))
        {
          theForm.Error(string.Empty, "Output folder doesn't exists");
          return;
        }

        if (!File.Exists(gridFilename))
        {
          theForm.Error(string.Empty, "Input grid file doesn't exists");
          return;
        }

        if (!File.Exists(shapefilename))
        {
          theForm.Error(string.Empty, "Input shapefile doesn't exists");
          return;
        }
        
        var resultGrid = Path.Combine(folder, "ClipGridByPolygonTest" + Path.GetExtension(gridFilename));
        if (File.Exists(resultGrid))
        {
          File.Delete(resultGrid);
        }

        var globalSettings = new GlobalSettings();
        globalSettings.ResetGdalError();
        var utils = new Utils { GlobalCallback = theForm };
        var sf = new Shapefile();
        sf.Open(shapefilename, theForm);
        var polygon = sf.get_Shape(0);

        // It returns false even if it is created
        if (!utils.ClipGridWithPolygon(gridFilename, polygon, resultGrid, false))
        {
          var msg = "Failed to process: " + utils.get_ErrorMsg(utils.LastErrorCode);
          if (globalSettings.GdalLastErrorMsg != string.Empty)
          {
            msg += Environment.NewLine + "GdalLastErrorMsg: " + globalSettings.GdalLastErrorMsg;
          }

          theForm.Error(string.Empty, msg);
        }

        if (File.Exists(resultGrid))
        {
          theForm.Progress(string.Empty, 100, resultGrid + " was successfully created");
          Fileformats.OpenGridAsLayer(resultGrid, theForm, true);
        }
        else
        {
          theForm.Error(string.Empty, "No grid was created");
        }
      }
      catch (Exception exception)
      {
        theForm.Error(string.Empty, "Exception: " + exception.Message);
      }

      theForm.Progress(string.Empty, 100, "The Clip grid by polygon test has finished.");
    }

    /// <summary>Run the Shapefile to grid test</summary>
    /// <param name="shapefilename">
    /// The shapefilename.
    /// </param>
    /// <param name="theForm">
    /// The the form.
    /// </param>
    internal static void RunShapefileToGridTest(string shapefilename, Form1 theForm)
    {
      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The Shapefile to grid test has started.", Environment.NewLine));

      try
      {
        // Check inputs:
        if (!CheckShapefileLocation(shapefilename, theForm))
        {
          return;
        }

        var folder = Path.GetDirectoryName(shapefilename);
        var resultGridFilename = Path.Combine(folder, "ShapefileToGridTest.asc");
        if (File.Exists(resultGridFilename))
        {
          File.Delete(resultGridFilename);
        }

        // Setup grid header:
        const int NumCols = 100;
        const int NumRows = 100;
        var sf = Fileformats.OpenShapefile(shapefilename, theForm);
        if (sf == null)
        {
          return;
        }

        double minX, minY, minZ, maxX, maxY, maxZ;
        sf.Extents.GetBounds(out minX, out minY, out minZ, out maxX, out maxY, out maxZ);
        var gridHeader = new GridHeader
        {
          NodataValue = -1,
          NumberCols = NumCols,
          NumberRows = NumRows,
          Projection = sf.Projection,
          Notes = "Created using ShapefileToGrid",
          XllCenter = minX,
          YllCenter = minY,
          dX = (maxX - minX) / NumCols,
          dY = (maxY - minY) / NumRows
        };

        var utils = new Utils { GlobalCallback = theForm };
        var resultGrid = utils.ShapefileToGrid(sf, false, gridHeader, 30, true, 1);
        if (resultGrid == null)
        {
          theForm.Error(string.Empty, "Error in ShapefileToGrid: " + utils.get_ErrorMsg(utils.LastErrorCode));
        }
        else
        {
          if (!resultGrid.Save(resultGridFilename, GridFileType.UseExtension, null))
          {
            theForm.Error(string.Empty, "Error in Grid.Save(): " + resultGrid.get_ErrorMsg(resultGrid.LastErrorCode));
          }
          else
          {
            Fileformats.OpenGridAsLayer(resultGridFilename, theForm, true);
            MyAxMap.AddLayer(sf, true);
          }
        }
      }
      catch (Exception exception)
      {
        theForm.Error(string.Empty, "Exception: " + exception.Message);
      }

      theForm.Progress(string.Empty, 100, "The Shapefile to grid test has finished.");
    }

    /// <summary>Run the Rasterize shapefile test</summary>
    /// <param name="shapefilename">
    /// The shapefilename.
    /// </param>
    /// <param name="theForm">
    /// The form.
    /// </param>
    internal static void RunRasterizeTest(string shapefilename, Form1 theForm)
    {
      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The Rasterize shapefile test has started.", Environment.NewLine));

      try
      {
        // Check inputs:
        if (!CheckShapefileLocation(shapefilename, theForm))
        {
          return;
        }

        // First check if the MWShapeID field is present:
        var sf = Fileformats.OpenShapefile(shapefilename, theForm);
        if (sf == null)
        {
          return;
        }

        // Get target resolution. The values must be expressed in georeferenced units (-tr):
        double minX, minY, minZ, maxX, maxY, maxZ;
        sf.Extents.GetBounds(out minX, out minY, out minZ, out maxX, out maxY, out maxZ);
        var resX = maxX - minX;
        var resY = maxY - minY;

        const string FieldName = "MWShapeID";
        if (sf.Table.get_FieldIndexByName(FieldName) == -1)
        {
          theForm.Progress(string.Empty, 0, "Adding " + FieldName + " as field");

          if (!sf.StartEditingShapes(true, theForm))
          {
            theForm.Error(string.Empty, "Could not put shapefile in edit mode: " + sf.get_ErrorMsg(sf.LastErrorCode));
            return;
          }

          if (sf.EditAddField(FieldName, FieldType.INTEGER_FIELD, 0, 10) == -1)
          {
            theForm.Error(string.Empty, "Could not add the fieldname: " + sf.get_ErrorMsg(sf.LastErrorCode));
            return;
          }

          if (!sf.StopEditingShapes(true, true, theForm))
          {
            theForm.Error(string.Empty, "Could not end shapefile in edit mode: " + sf.get_ErrorMsg(sf.LastErrorCode));
            return;
          }
        }

        if (!sf.Close())
        {
          theForm.Error(string.Empty, "Could not close the shapefile: " + sf.get_ErrorMsg(sf.LastErrorCode));
          return;
        }

        var folder = Path.GetDirectoryName(shapefilename);
        var utils = new Utils { GlobalCallback = theForm };
        var globalSettings = new GlobalSettings();
        globalSettings.ResetGdalError();
        var outputFile = Path.Combine(folder, "GDALRasterizeTest.tif");
        if (File.Exists(outputFile))
        {
          File.Delete(outputFile);
        }

        var options = string.Format(
          "-a {0} -l {1} -of GTiff -a_nodata -999 -init -999 -ts 800 800",
          FieldName,
          Path.GetFileNameWithoutExtension(shapefilename));
        System.Diagnostics.Debug.WriteLine(options);
        if (!utils.GDALRasterize(shapefilename, outputFile, options, theForm))
        {
          var msg = " in GDALRasterize: " + utils.get_ErrorMsg(utils.LastErrorCode);
          if (globalSettings.GdalLastErrorMsg != string.Empty)
          {
            msg += Environment.NewLine + "GdalLastErrorMsg: " + globalSettings.GdalLastErrorMsg;
          }

          theForm.Error(string.Empty, msg);
          return;
        }

        // Open the files:
        Fileformats.OpenImageAsLayer(outputFile, theForm, true);
        Fileformats.OpenShapefileAsLayer(shapefilename, theForm, false);
      }
      catch (Exception exception)
      {
        theForm.Error(string.Empty, "Exception: " + exception.Message);
      }

      theForm.Progress(string.Empty, 100, "The Rasterize shapefile test has finished.");
    }

    /// <summary>Run the Rasterize shapefile test</summary>
    /// <param name="shapefilename">
    /// The shapefilename.
    /// </param>
    /// <param name="theForm">
    /// The form.
    /// </param>
    internal static void RunBufferShapefileTest(string shapefilename, Form1 theForm)
    {
      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The Buffer shapefile test has started.", Environment.NewLine));

      try
      {
        // Check inputs:
        if (!CheckShapefileLocation(shapefilename, theForm))
        {
          return;
        }

        // Open the sf:
        // First check if the MWShapeID field is present:
        var sf = Fileformats.OpenShapefile(shapefilename, theForm);
        if (sf == null)
        {
          theForm.Error(string.Empty, "Opening input shapefile was unsuccessful");
          return;
        }

        var globalSettings = new GlobalSettings();
        globalSettings.ResetGdalError();
        theForm.Progress(string.Empty, 0, "Start buffering " + Path.GetFileName(shapefilename));
        
        // Make the distance depending on the projection.
        var distance = 1000;
        if (sf.GeoProjection.IsGeographic)
        {
          distance = 1;
        }

        var bufferedSf = sf.BufferByDistance(distance, 16, false, false);

        // Do some checks:
        if (!CheckShapefile(sf, bufferedSf, globalSettings.GdalLastErrorMsg, theForm))
        {
          return;
        }

        // Load the files:
        Fileformats.OpenShapefileAsLayer(shapefilename, theForm, true);
        bufferedSf.DefaultDrawingOptions.FillVisible = false;
        MyAxMap.AddLayer(bufferedSf, true);
      }
      catch (Exception exception)
      {
        theForm.Error(string.Empty, "Exception: " + exception.Message);
      }

      theForm.Progress(string.Empty, 100, "The Buffer shapefile test has finished.");
    }

    /// <summary>Run the Simplify shapefile test</summary>
    /// <param name="shapefilename">The shapefile name</param>
    /// <param name="theForm">The form</param>
    internal static void RunSimplifyShapefileTest(string shapefilename, Form1 theForm)
    {
      theForm.Progress(
        string.Empty,
        0,
        string.Format("{0}-----------------------{0}The Simplify shapefile test has started.", Environment.NewLine));

      try
      {
        // Check inputs:
        if (!CheckShapefileLocation(shapefilename, theForm))
        {
          return;
        }

        // Open the sf:
        var sf = Fileformats.OpenShapefile(shapefilename, theForm);
        if (sf == null)
        {
          theForm.Error(string.Empty, "Opening input shapefile was unsuccessful");
          return;
        }

        var globalSettings = new GlobalSettings();
        globalSettings.ResetGdalError();
        theForm.Progress(string.Empty, 0, "Start simplifying " + Path.GetFileName(shapefilename));

        // Make the tolerance depending on the projection.
        var tolerance = 10d;
        if (sf.GeoProjection.IsGeographic)
        {
          tolerance = 1;
        }

        var simplifiedSf = sf.SimplifyLines(tolerance, false);

        // Do some checks:
        if (!CheckShapefile(sf, simplifiedSf, globalSettings.GdalLastErrorMsg, theForm))
        {
          return;
        }

        // give the resulting lines a good width and color:
        var utils = new Utils { GlobalCallback = theForm };
        simplifiedSf.DefaultDrawingOptions.LineWidth = 2;
        simplifiedSf.DefaultDrawingOptions.LineColor = utils.ColorByName(tkMapColor.OrangeRed);
        simplifiedSf.DefaultDrawingOptions.LineStipple = tkDashStyle.dsSolid;

        // Load the files:
        MyAxMap.RemoveAllLayers();
        MyAxMap.AddLayer(simplifiedSf, true);
        Fileformats.OpenShapefileAsLayer(shapefilename, theForm, false);
      }
      catch (Exception exception)
      {
        theForm.Error(string.Empty, "Exception: " + exception.Message);
      }

      theForm.Progress(string.Empty, 100, "The Simplify shapefile test has finished.");
    }

    /// <summary>Check the given shapefile location</summary>
    /// <param name="shapefilename">
    /// The shapefilename.
    /// </param>
    /// <param name="theForm">
    /// The the form.
    /// </param>
    /// <returns>True when no errors else false</returns>
    private static bool CheckShapefileLocation(string shapefilename, ICallback theForm)
    {
      if (shapefilename == string.Empty)
      {
        theForm.Error(string.Empty, "Input parameters are wrong");
        return false;
      }

      var folder = Path.GetDirectoryName(shapefilename);
      if (folder == null)
      {
        theForm.Error(string.Empty, "Input parameters are wrong");
        return false;
      }

      if (!Directory.Exists(folder))
      {
        theForm.Error(string.Empty, "Output folder doesn't exists");
        return false;
      }

      if (!File.Exists(shapefilename))
      {
        theForm.Error(string.Empty, "Input shapefile doesn't exists");
        return false;
      }

      return true;
    }

    /// <summary>Check if the resulting shapefile is correct</summary>
    /// <param name="inputSf">
    /// The input sf.
    /// </param>
    /// <param name="resultingSf">
    /// The resulting sf.
    /// </param>
    /// <param name="gdalLastErrorMsg">
    /// The gdal last error msg.
    /// </param>
    /// <param name="theForm">
    /// The the form.
    /// </param>
    /// <returns>True when no errors else false</returns>
    private static bool CheckShapefile(IShapefile inputSf, IShapefile resultingSf, string gdalLastErrorMsg, ICallback theForm)
    {
      if (resultingSf == null)
      {
        var msg = "The resulting shapefile was not created: " + inputSf.get_ErrorMsg(inputSf.LastErrorCode);
        if (gdalLastErrorMsg != string.Empty)
        {
          msg += Environment.NewLine + "GdalLastErrorMsg: " + gdalLastErrorMsg;
        }

        theForm.Error(string.Empty, msg);
        return false;
      }

      if (resultingSf.NumShapes < -1)
      {
        theForm.Error(string.Empty, "Resulting shapefile has no shapes");
        return false;
      }

      if (resultingSf.HasInvalidShapes())
      {
        theForm.Error(string.Empty, "Resulting shapefile has invalid shapes");
        return false;
      }

      if (resultingSf.NumFields < -1)
      {
        theForm.Error(string.Empty, "Resulting shapefile has no fields");
        return false;
      }

      return true;
    }
  }
}