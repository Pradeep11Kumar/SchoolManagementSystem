using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.ViewModel.GroupClass;

namespace SchoolManagement.Controllers
{
    public class GroupClassController : Controller
    { 
        private readonly StudentContext _studentContext;
         public GroupClassController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IActionResult Index()
        {
            var model = _studentContext.GroupClasses.ToList();
            if (model == null)
            {
            return NotFound();
            }
            var viewModelList = new List<GroupClassViewModel>();
            foreach (var groupClass in model)
            {
                viewModelList.Add(new GroupClassViewModel
                {
                    GroupId = groupClass.Id,
                    GroupClassName = groupClass.Name,
                });
            }
            return View(viewModelList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateGroupClassViewModel createGroupClassViewModel)
        {

            var viewModelList = new GroupClass
            {
                Name = createGroupClassViewModel.GroupClassName,

            };
            _studentContext.GroupClasses.Add(viewModelList);
            _studentContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int classId)
        { 
            var model = _studentContext.GroupClasses.Find(classId);
            if (model == null) 
            {
                return NotFound();
            }
            var modelList = new EditGroupClassViewModel
            {
                GroupId = model.Id,
                StudentCreateGroupClass = new CreateGroupClassViewModel
                {
                    GroupClassName = model.Name,
                }
            };
            return View(modelList);
        }

        [HttpPost]
        public IActionResult Edit(EditGroupClassViewModel editGroupClassViewModel)
        {
            var model = _studentContext.GroupClasses.Find(editGroupClassViewModel.GroupId);
            if (model == null) { return NotFound(); }

            model.Name = editGroupClassViewModel.StudentCreateGroupClass.GroupClassName;

            _studentContext.GroupClasses.Update(model);
            _studentContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int classId)
        {
            var model = _studentContext.GroupClasses.Find(classId);
            if (model == null)
            {
                return NotFound();
            }
            _studentContext.GroupClasses.Remove(model);
            _studentContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
