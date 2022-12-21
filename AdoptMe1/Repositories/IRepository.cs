using AdoptMe1.Data;
using AdoptMe1.Models;

namespace AdoptMe1.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<Animal>> GetAnimalsAsync();
        Task<Animal> GetAnimalByNameAsync(string name);
        Task<Animal> GetAnimalByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(int categoryId);
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByAnimalAsync(Animal animal);
        Task<IEnumerable<Login>> GetUsersAsync();
        bool PasswordConfirm(string password);
        Task<List<Animal>> GetTopTwoAsync();
        //
        //
        void InsertAnimal(Animal animal);
        void DeleteAnimal(int id);
        void InsertComment(Comment comment);
        void DeleteComment(int id);

        void UpdateAnimal(int id, Animal animal);
        
    }
}
