using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;
using MVCExamProject.ViewModel;
using System.Linq;
using MVCExamProject.Enums;
using MVCExamProject.Repository;

namespace MVCExamProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ExamController : Controller
    {
        private readonly IExamRepository ExamRepo;
        private readonly IExamQuestionRepository QuestionRepo;
        private readonly IQuestionOptionRepository OptionRepo;

        public ExamController(
            IExamRepository _examRepo,
            IExamQuestionRepository questionRepo,
            IQuestionOptionRepository optionRepo
        )
        {
            this.ExamRepo = _examRepo;
            QuestionRepo = questionRepo;
            OptionRepo = optionRepo;

        }

        [Route("admin/exams")]
        public IActionResult Index()
        {
            var exams = ExamRepo.GetAll();
            string responseData = TempData["ResponseData"] as string;
            if (!string.IsNullOrEmpty(responseData))
            {
                ViewData["Response"] = responseData;
            }
            return View("~/Views/Admin/Exam/index.cshtml" , exams);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/exams/create")]
        public IActionResult Create(ExamViewModel data)
        {
            if (ModelState.IsValid)
            {
                // save exam
                Exam exam = new Exam() { Name = data.Title, QuestionCount = int.Parse(data.QuetionsCount) };
                ExamRepo.Insert(exam);

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

                    int answerNumber = int.Parse(Request.Form["Checks" + i]);
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

                OptionRepo.SaveChanges(); // Save changes to the database
                TempData["ResponseData"] = Responses.success.ToString();
            }
            else
            {
                TempData["ResponseData"] = Responses.fail.ToString();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("admin/exams/create")]
        public IActionResult Create()
        {

            return View("~/Views/Admin/Exam/create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ExamViewModel data, int id)
        {
            try
            {
                Exam exam = ExamRepo.GetById(id);
                ExamRepo.Delete(exam);
                TempData["ResponseData"] = Responses.success.ToString();
               
            }
            catch(Exception e)
            {
                TempData["ResponseData"] = Responses.fail.ToString();
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/exams/{id}/edit")]
        public IActionResult Edit(Exam exam)
        {
            var request = Request.Form;
            ExamRepo.Update(exam , request);
            TempData["ResponseData"] = Responses.success.ToString();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("admin/exams/{id}/edit")]
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                Exam exam = ExamRepo.getExam(id);

                return View("~/Views/Admin/Exam/edit.cshtml" , exam);
            }
            return RedirectToActionPermanent("Index");
        }

    }
}
