using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCExamProject.Models;
using MVCExamProject.Repository;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Controllers
{
	public class StudController : Controller
	{
		private readonly IExamRepository examService;
        private readonly IExamQuestionRepository examQuestionService;
        private readonly IQuestionOptionRepository questionOptionService;

        public StudController(IExamRepository examService,IExamQuestionRepository examQuestionService,IQuestionOptionRepository questionOptionService)
        {
			this.examService = examService;
            this.examQuestionService = examQuestionService;
            this.questionOptionService = questionOptionService;
        }

	

		public IActionResult ChooseExam()
		{
			var exams = examService.GetAll();
			return View(exams);
		}
		public IActionResult ExamQuestions(int Id)
		{
            var examQuestions = examQuestionService.getByExamId(Id);
            var questionOptions = questionOptionService.getForQuestionsList(examQuestions as List<ExamQuestion>);

            ViewBag.examOptions = questionOptions;

            return View(examQuestions);
        }
        public IActionResult Result()
        {
            return View();
        }

    }
}
