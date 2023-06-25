using MVCExamProject.Data;
using MVCExamProject.Models;

namespace MVCExamProject.Repository
{
    public class ContactUsService : IRepository<ContactUs>
    {
        private readonly ExamContext context;

        public ContactUsService(ExamContext context)
        {
            this.context = context;
        }
        public void Delete(ContactUs t)
        {
            context.Remove(t);
        }

        public List<ContactUs> GetAll()
        {
            return context.ContactUsMSGS.ToList();
        }

        public ContactUs GetById(int id)
        {
            return context.ContactUsMSGS.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(ContactUs t)
        {
            context.ContactUsMSGS.Add(t);
        }

        public void Update(ContactUs t)
        {
            context.ContactUsMSGS.Update(t);
        }
    }
}
