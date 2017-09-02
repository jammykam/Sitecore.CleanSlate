using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Install.Framework;
using Sitecore.Web;
using System.Collections.Specialized;

namespace Sitecore.CleanSlate
{
    public class PostStepDelete : IPostStep
    {
        public void Run(ITaskOutput output, NameValueCollection metaData)
        {
            var parameters = WebUtil.ParseUrlParameters(metaData["Attributes"], '|');

            Database db = Factory.GetDatabase(parameters["database"]);
            string[] items = parameters["items"].Split(',');

            foreach (var i in items)
            {
                Item item = db.GetItem(i);
                if (item != null)
                {
                    Log.Info("Post Install Delete : " + item.Paths.FullPath, this);
                    item.Delete();
                }
            }
        }
    }
}
