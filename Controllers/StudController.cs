using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCExamProject.Models;
using MVCExamProject.Repository;
using MVCExamProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MVCExamProject.Controllers
{
	public class StudController : Controller
	{
		private readonly IExamRepository examService;
        private readonly IExamQuestionRepository examQuestionService;
        private readonly IQuestionOptionRepository questionOptionService;
        private readonly IUserExamRepository userExamService;

        public StudController(IExamRepository examService,IExamQuestionRepository examQuestionService,IQuestionOptionRepository questionOptionService,IUserExamRepository userExamService)
        {
			this.examService = examService;
            this.examQuestionService = examQuestionService;
            this.questionOptionService = questionOptionService;
            this.userExamService = userExamService;
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            foreach (int id in optionsId)
            {
                var option = questionOptionService.GetById(id);
                if (option != null && option.IsRight == true)
                {
                    count++;
                }      
            }
            var exam = userExamService.getExamByUserId(int.Parse(userId));

            if (count >= 5)
            {
                exam.IsPassed = true;

            } else { exam.IsPassed = false; }

            exam.Degree = count;
            exam.CreatedAt = DateTime.Now;
            userExamService.Save();

            ViewBag.ResultCount = count;

            return View(exam);
        }

    }
}
