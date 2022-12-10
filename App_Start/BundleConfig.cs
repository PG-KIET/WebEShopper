using System.Web;
using System.Web.Optimization;

namespace WebEShopper
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			//Add css for public
			bundles.Add(new StyleBundle("~/Content/css").Include(
											"~/Content/bootstrap.css",
											"~/Content/site.css"));
			//Add css for privatepages
			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
											"~/Scripts/jquery.validate*"));
			//add js for public
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
											"~/Scripts/modernizr-*"));
			//add js for privatepages
			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
											"~/Scripts/bootstrap.js"));

		
		}
	}
}
