using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;
using MVCExamProject.ViewModel;
using System.Linq;

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ExamController : Controller
    {
        private IExamRepository ExamRepo;
        private IExamQuestionRepository QuestionRepo;
        private IQuestionOptionRepository OptionRepo;

        public ExamController(IExamRepository _examRepo, IExamQuestionRepository questionRepo, IQuestionOptionRepository optionRepo)
        {
            this.ExamRepo = _examRepo;
            QuestionRepo = questionRepo;
            OptionRepo = optionRepo;

        }

        //[Authorize("Admin")]
        [Route("admin/exams")]
        public IActionResult Index()
        {
            var exams = ExamRepo.GetAll();
            return View("~/Views/Admin/Exam/index.cshtml" , exams);
        }

        //[Authorize("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/exams/create")]
        [HttpPost]
        public IActionResult Create(ExamViewModel data)
        {
            if (ModelState.IsValid)
            {
                // save exam
                Exam exam = new Exam() { Name = data.Title, QuestionCount = int.Parse(data.QuetionsCount) };
                ExamRepo.Insert(exam);

                // Bind the form data to the ExamViewModel
                int questionsCount = int.Parse(data.QuetionsCount);
                for (int i = 1; i <= questionsCount; i++)
                {
                    string questionTitle = Request.Form["Titles" + i];
                    ExamQuestion question = new ExamQuestion()
                    {
                        Title = questionTitle,
                        ExamId = exam.Id
                    };
                    QuestionRepo.Insert(question);

                    int answerNumber = int.Parse( Request.Form["Checks" + i] );
                    var QuestionOptions = new List<string>();
                    for (int s = 1; s <= 4; s++)
                    {

                        string optionTitle = Request.Form["Options" + i + s];
                        QuestionOption option = new QuestionOption()
                        {
                            Title = optionTitle,
                            IsRight = (answerNumber == s) ? true : false,
                            ExamQuestionId = question.Id
                        };
                        OptionRepo.Insert(option);
                    }

                }

                
            }

            return RedirectToActionPermanent("Index");
        }


        //[Authorize("Admin")]
        [HttpGet]
        [Route("admin/exams/create")]
        public IActionResult Create()
        {

            return View("~/Views/Admin/Exam/create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ExamRepo.Delete(id);
            return RedirectToActionPermanent("Index");
        }

    }
}
