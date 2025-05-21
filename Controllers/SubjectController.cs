using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.ViewModel.Subject;

namespace SchoolManagement.Controllers
{
    public class SubjectController(StudentContext _studentContext) : Controller
    {
        public IActionResult Index()
        {
            var model = _studentContext.subjects.ToList();
            var viewModelList = new List<SubjectViewModel>();
            foreach (var subject in model)
            {
                viewModelList.Add(new SubjectViewModel
                {
                    Id = subject.Id,
                    SubjectName = subject.Name
                });
            }

            return View(viewModelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSubjectViewModel vm)
        {
            var model = new Subject
            {
                Name = vm.SubjectName
            };
            _studentContext.subjects.Add(model);
            _studentContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int subjectId)
        {
            var model = _studentContext.subjects.Find(subjectId);
            if (model == null)
            {
                return NotFound();
            }
            var viewModel = new EditSubjectViewModel
            {
                SubjectId = subjectId,
                StudentSubject = new CreateSubjectViewModel
                {
                    SubjectName = model.Name
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditSubjectViewModel vm)
        {
            var model = _studentContext.subjects.Find(vm.SubjectId);
            if (model == null) 
            {
                return NotFound();
            }
            model.Name = vm.StudentSubject.SubjectName;
            _studentContext.Update(model);
            _studentContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int subjectId)
        {
            var model = _studentContext.subjects.Find(subjectId);
            if (model == null) { return NotFound(); }
            _studentContext.subjects.Remove(model);
            _studentContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
