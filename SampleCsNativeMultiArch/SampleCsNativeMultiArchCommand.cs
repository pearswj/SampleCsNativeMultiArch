using System;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace SampleCsNativeMultiArch
{
  public class SampleCsNativeMultiArchCommand : Rhino.Commands.Command
  {
    public override string EnglishName
    {
      get { return "SampleCsNativeMultiArchCommand"; }
    }

    protected override Result RunCommand(Rhino.RhinoDoc doc, RunMode mode)
    {
      IntPtr version;
      try
      {
        version = UnsafeNativeMethods.curl_version();
      }
      catch (Exception e)
      {
        RhinoApp.WriteLine("ERROR: " + e.Message);
        RhinoApp.WriteLine("Couldn't load libcurl");
        return Result.Failure;
      }

      RhinoApp.WriteLine("Successfully loaded libcurl, version: " + version.ToString());
      return Result.Success;
    }
  }
}
