using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WallPostByTechBrij.Controllers
{
    public class ManageDocController : Controller
    {
        //
        // GET: /ManageDoc/

        public ActionResult Index()
        {
            var locations = GetLocations();

            return View(locations);
        }

        public static List<TreeViewLocation> GetLocations()
        {
            var locations = new List<TreeViewLocation>
                                {
                                    new TreeViewLocation
                                        {
                                            Name = "United States",
                                            ChildLocations =
                                                {
                                                    new TreeViewLocation
                                                        {
                                                            Name = "Chicago",
                                                            ChildLocations =
                                                                {
                                                                    new TreeViewLocation {Name = "Rack 1"},
                                                                    new TreeViewLocation {Name = "Rack 2"},
                                                                    new TreeViewLocation {Name = "Rack 3"},
                                                                }
                                                        },
                                                    new TreeViewLocation {Name = "Dallas"}
                                                }
                                        },
                                    new TreeViewLocation
                                        {
                                            Name = "Canada",
                                            ChildLocations =
                                                {
                                                    new TreeViewLocation {Name = "Ontario"},
                                                    new TreeViewLocation {Name = "Windsor"}
                                                }
                                        }
                                };
            return locations;
        }
    }
}
