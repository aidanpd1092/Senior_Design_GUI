/*
* MATLAB Compiler: 5.1 (R2014a)
* Date: Sun Apr 12 18:44:04 2015
* Arguments: "-B" "macro_default" "-W" "dotnet:spiro_data_reading,spirofunc,0.0,private"
* "-T" "link:lib" "-d"
* "\\Client\C$\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\spiro_data_reading\f
* or_testing" "-v"
* "\\Client\C$\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\spiro_data_reading.m
* "
* "class{spirofunc:\\Client\C$\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\spir
* o_data_reading.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace spiro_data_readingNative
{

  /// <summary>
  /// The spirofunc class provides a CLS compliant, Object (native) interface to the
  /// MATLAB functions contained in the files:
  /// <newpara></newpara>
  /// \\Client\C$\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code\spiro_data_readin
  /// g.m
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
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "spiro_data_reading.ctf";

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
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the spirofunc class.
    /// </summary>
    public spirofunc()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
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
    /// Provides a single output, 0-input Objectinterface to the spiro_data_reading
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object spiro_data_reading()
    {
      return mcr.EvaluateFunction("spiro_data_reading", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the spiro_data_reading
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="Subject_number">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object spiro_data_reading(Object Subject_number)
    {
      return mcr.EvaluateFunction("spiro_data_reading", Subject_number);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the spiro_data_reading
    /// MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="Subject_number">Input argument #1</param>
    /// <param name="trial">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object spiro_data_reading(Object Subject_number, Object trial)
    {
      return mcr.EvaluateFunction("spiro_data_reading", Subject_number, trial);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the spiro_data_reading MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] spiro_data_reading(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiro_data_reading", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the spiro_data_reading MATLAB
    /// function.
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
    public Object[] spiro_data_reading(int numArgsOut, Object Subject_number)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiro_data_reading", Subject_number);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the spiro_data_reading MATLAB
    /// function.
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
    public Object[] spiro_data_reading(int numArgsOut, Object Subject_number, Object 
                                 trial)
    {
      return mcr.EvaluateFunction(numArgsOut, "spiro_data_reading", Subject_number, trial);
    }


    /// <summary>
    /// Provides an interface for the spiro_data_reading function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// save the results in a file
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("spiro_data_reading", 2, 2, 0)]
    protected void spiro_data_reading(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("spiro_data_reading", numArgsOut, ref argsOut, argsIn, varArgsIn);
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

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
