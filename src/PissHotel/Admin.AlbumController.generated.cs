// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
#pragma warning disable 1591, 3008, 3009
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace PissHotel.Areas.Admin.Controllers
{
    public partial class AlbumController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AlbumController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AlbumController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteFile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteFile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AddFile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddFile);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AlbumController Actions { get { return MVC.Admin.Album; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Album";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Album";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string List = "List";
            public readonly string Delete = "Delete";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string DeleteFile = "DeleteFile";
            public readonly string AddFile = "AddFile";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string List = "List";
            public const string Delete = "Delete";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string DeleteFile = "DeleteFile";
            public const string AddFile = "AddFile";
        }


        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string vm = "vm";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string id = "id";
            public readonly string vm = "vm";
        }
        static readonly ActionParamsClass_DeleteFile s_params_DeleteFile = new ActionParamsClass_DeleteFile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteFile DeleteFileParams { get { return s_params_DeleteFile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteFile
        {
            public readonly string albumId = "albumId";
            public readonly string fileName = "fileName";
        }
        static readonly ActionParamsClass_AddFile s_params_AddFile = new ActionParamsClass_AddFile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddFile AddFileParams { get { return s_params_AddFile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddFile
        {
            public readonly string albumId = "albumId";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Create = "Create";
                public readonly string Edit = "Edit";
                public readonly string List = "List";
            }
            public readonly string Create = "~/Areas/Admin/Views/Album/Create.cshtml";
            public readonly string Edit = "~/Areas/Admin/Views/Album/Edit.cshtml";
            public readonly string List = "~/Areas/Admin/Views/Album/List.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AlbumController : PissHotel.Areas.Admin.Controllers.AlbumController
    {
        public T4MVC_AlbumController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult List()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.List);
            ListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, PissHotel.Areas.Admin.Models.AlbumVM vm);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(PissHotel.Areas.Admin.Models.AlbumVM vm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vm", vm);
            CreateOverride(callInfo, vm);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, PissHotel.Areas.Admin.Models.AlbumVM vm);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(PissHotel.Areas.Admin.Models.AlbumVM vm)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "vm", vm);
            EditOverride(callInfo, vm);
            return callInfo;
        }

        [NonAction]
        partial void DeleteFileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int albumId, string fileName);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteFile(int albumId, string fileName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteFile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "albumId", albumId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "fileName", fileName);
            DeleteFileOverride(callInfo, albumId, fileName);
            return callInfo;
        }

        [NonAction]
        partial void AddFileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int albumId);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddFile(int albumId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddFile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "albumId", albumId);
            AddFileOverride(callInfo, albumId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
