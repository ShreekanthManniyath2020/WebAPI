using Application.DataLayer.DB;
using Application.DataLayer.DB.Implementation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected MongoCRUD db;
        public BaseController()
        {
            db = new MongoCRUD("AngularApplicationDB");
        }
    }
}
