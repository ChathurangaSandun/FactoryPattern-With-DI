using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
  public class ApplicationSettings
  {
    public MainReportInformationSettings SimpleReportInformation { get; set; }
    public MainReportInformationSettings ComplexReportInformation { get; set; }
  }

  public class MainReportInformationSettings
  {
    public string DefaultConfigFileName { get; set; }
    public string ReportCodePrefix { get; set; }
    public IList<string> ParentFolderPaths { get; set; }
  }
}
