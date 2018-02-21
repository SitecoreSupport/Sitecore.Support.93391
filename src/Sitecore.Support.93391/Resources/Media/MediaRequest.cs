namespace Sitecore.Support.Resources.Media
{
    using Sitecore.Reflection;
    using Sitecore.Resources.Media;
    using Sitecore.Web;
    using System;
    using System.Web;

    public class MediaRequest : Sitecore.Resources.Media.MediaRequest
    {
        public override Sitecore.Resources.Media.MediaRequest Clone()
        {
            Sitecore.Support.Resources.Media.MediaRequest url = new Sitecore.Support.Resources.Media.MediaRequest();
            ReflectionUtil.SetField(url, "innerRequest", ReflectionUtil.GetField(this, "innerRequest"));
            ReflectionUtil.SetField(url, "mediaUri", ReflectionUtil.GetField(this, "mediaUri"));
            ReflectionUtil.SetField(url, "options", ReflectionUtil.GetField(this, "options"));
            ReflectionUtil.SetField(url, "mediaQueryString", ReflectionUtil.GetField(this, "mediaQueryString"));
            return url;
        }

        protected override string GetMediaPath()
        {
            string absolutePath = HttpContext.Current.Request.Url.AbsolutePath;
            if (WebUtil.Is404Request(absolutePath))
            {
                absolutePath = WebUtil.GetRequestUri404(absolutePath);
            }
            string localPath = WebUtil.GetLocalPath(absolutePath);
            return this.GetMediaPath(localPath);
        }
    }
}
