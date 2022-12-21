using Microsoft.AspNetCore.Mvc;

namespace AdoptMe1.Views.Shared.Components
{
    public class ImageUploaderViewComponent : ViewComponent
    {
        public ImageUploaderViewComponent()
        {

        }
        public IViewComponentResult Invoke(string FieldName)
        {
            return View("Default", FieldName);
        }
    }
}
