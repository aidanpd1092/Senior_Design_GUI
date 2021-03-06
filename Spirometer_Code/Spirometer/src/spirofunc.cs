/*
* MATLAB Compiler: 4.16 (R2011b)
* Date: Tue Apr 14 12:21:43 2015
* Arguments: "-B" "macro_default" "-W" "dotnet:Spirometer,spirofunc,0.0,private" "-T"
* "link:lib" "-d"
* "C:\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\Spirometer\src" "-w"
* "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v"
* "class{spirofunc:C:\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\spiro_data_re
* ading.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace Spirometer
{

  /// <summary>
  /// The spirofunc class provides a CLS compliant, MWArray interface to the M-functions
  /// contained in the files:
  /// <newpara></newpara>
  /// C:\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\spiro_data_reading.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class spirofunc : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static spirofunc()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = "Spirometer.ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR("",
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the spirofunc class.
    /// </summary>
    public spirofunc()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~spirofunc()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the spiro_data_reading
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray spiro_data_reading()
    {
      return mcr.EvaluateFunction("spiro_data_reading", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the spiro_data_reading
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="Subject_number">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray spiro_data_reading(MWArray Subject_number)
    {
      return mcr.EvaluateFunction("spiro_data_reading", Subject_number);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the spiro_data_reading
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="Subject_number">Input argument #1</param>
    /// <param name="trial">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray spiro_data_reading(MWArray Subject_number, MWArray trial)
    {
      return mcr.EvaluateFunction("spiro_data_reading", Subject_number, trial);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the spiro_data_reading
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] spiro_data_reading(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiro_data_reading", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the spiro_data_reading
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Subject_number">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] spiro_data_reading(int numArgsOut, MWArray Subject_number)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiro_data_reading", Subject_number);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the spiro_data_reading
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Subject_number">Input argument #1</param>
    /// <param name="trial">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] spiro_data_reading(int numArgsOut, MWArray Subject_number, MWArray 
                                  trial)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiro_data_reading", Subject_number, trial);
    }


    /// <summary>
    /// Provides an interface for the spiro_data_reading function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void spiro_data_reading(int numArgsOut, ref MWArray[] argsOut, MWArray[] 
                         argsIn)
    {
      mcr.EvaluateFunction("spiro_data_reading", numArgsOut, ref argsOut, argsIn);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
