using AdoptMe1.Data;
using AdoptMe1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptMe1.Repositories
{
    public class MyRepository : IRepository
    {
        private readonly MyContext _data;

        public MyRepository(MyContext data)
        {
            _data = data;
        }

        //Get
        private IEnumerable<Animal> GetAnimals() =>  _data.Animals!;
        public Task<IEnumerable<Animal>> GetAnimalsAsync() => Task.Run(() => GetAnimals());
        private IEnumerable<Category> GetCategories() => _data.Categories!;
        public Task<IEnumerable<Category>> GetCategoriesAsync() => Task.Run(() => GetCategories());
        private IEnumerable<Comment> GetComments() => _data.Comments!;
        public Task<IEnumerable<Comment>> GetCommentsAsync() => Task.Run(() => GetComments());
        private IEnumerable<Login> GetUsers() => _data.Logins!;
        public Task<IEnumerable<Login>> GetUsersAsync() => Task.Run(() => GetUsers());
        
        private Animal GetAnimalByName(string name) => _data.Animals!.First(a => a.Name == name);
        public Task<Animal> GetAnimalByNameAsync(string name) => Task.Run(() => GetAnimalByName(name));
        private Animal GetAnimalById(int Id) => _data.Animals!.First(a => a.AnimalId == Id);
        public Task<Animal> GetAnimalByIdAsync(int Id) => Task.Run(() => GetAnimalById(Id));
        private IEnumerable<Comment> GetCommentsByAnimal(Animal animal) => _data.Comments!.Where(a => a.AnimalId == animal.AnimalId);
        public Task<IEnumerable<Comment>> GetCommentsByAnimalAsync(Animal animal) => Task.Run(() => GetCommentsByAnimal(animal));
        private List<Animal> GetTopTwo() => _data.Animals!.Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();
        public Task<List<Animal>> GetTopTwoAsync() => Task.Run(() => GetTopTwo());
        private IEnumerable<Animal> GetAnimalsByCategory(int categoryId) => _data.Animals!.Where(c => c.CategoryId == categoryId).ToList();
        public Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(int categoryId) => Task.Run(() => GetAnimalsByCategory(categoryId));
        private IEnumerable<Animal> GetTopTwoByCategory(int categoryId) => _data.Animals!.Where(c => c.CategoryId == categoryId).Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();
        public Task<IEnumerable<Animal>> GetTopTwoByCategoryAsync(int categoryId) => Task.Run(() => GetTopTwoByCategory(categoryId));
        //Inserting
        public void InsertAnimal(Animal animal)
        {
            _data.Animals!.Add(animal);
            _data.SaveChanges();
        }
        public void InsertComment(Comment comment)
        {      
            _data.Comments!.Add(comment);
            _data.SaveChanges();
        }
        
        //Deleting
        public void DeleteAnimal(int id)
        {
            var animal = _data.Animals!.Single(a => a.AnimalId == id);
            _data.Animals!.Remove(animal);
            _data.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var comment = _data.Comments!.Single(a => a.CommentId == id);
            _data.Comments!.Remove(comment);
            _data.SaveChanges();
        }
       
        //Update
        public void UpdateAnimal(int id, Animal animal)
        {
            var AnimalInDB = _data.Animals!.Single(a => a.AnimalId == id);
            AnimalInDB = animal;
            _data.SaveChanges();
        }
        public bool PasswordConfirm(string password)
        {
            var users = GetUsers();
            foreach (var user in users)
            {
                if (user.Password == password)
                    return false;
            }
            return true;
        }
    }
}
//protected override void OnModelCreating(DbModelBuilder modelBuilder)
//{
//    new Book { Id = Guid.NewGuid(), Title = "Harry Potter 1", Author = "J.K Rowling", Price = 15, Quantity = 20, Genre = BooksGenre.Fantasy, Description = "This is the tale of Harry Potter (Daniel Radcliffe), an ordinary eleven-year-old boy serving as a sort of slave for his aunt and uncle who learns that he is actually a wizard and has been invited to attend the Hogwarts School for Witchcraft and Wizardry.\r\n" };
//    new Book { Id = Guid.NewGuid(), Title = "Harry Potter 2", Author = "J.K Rowling", Price = 12, Quantity = 27, Genre = BooksGenre.Fantasy, Description = "The story follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, where the Heir of Salazar Slytherin opens the Chamber of Secrets, unleashing a monster that petrifies the school's students. The film is the sequel to Harry Potter and the Philosopher's Stone (2001).\r\n" };
//    new Journal { Id = Guid.NewGuid(), Title = "Vouge", Genre = JournalsGenre.Fashion, Quantity = 15, Price = 5.5, Publisher = "Condé Montrose Nast" };
//    new Journal { Id = Guid.NewGuid(), Title = "Sport ", Genre = JournalsGenre.Sport, Quantity = 10, Price = 5, Publisher = "Wireless Group" };
//}