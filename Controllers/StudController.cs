using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCExamProject.Models;
using MVCExamProject.Repository;
using MVCExamProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


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
            var questionsAndOptions = examService.getExam(Id).ExamQuestions.ToList();
            return View(questionsAndOptions);
        }
        [HttpPost]
        public IActionResult Result(List<int> optionsId)
        { 
            int count = 0;
            foreach (int id in optionsId)
            {
                var option = questionOptionService.GetById(id);
                if (option != null && option.IsRight == true)
                {
                    count++;
                }      
            }

            ViewBag.ResultCount = count;

            return View();
        }

    }
}
