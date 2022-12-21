using AdoptMe1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace AdoptMe1.Data
{
    public class MyContext : IdentityDbContext<IdentityUser>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Login>? Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, CategoryName = "Mammals" },
                new { CategoryId = 2, CategoryName = "Retiles" },
                new { CategoryId = 3, CategoryName = "Fish" },
                new { CategoryId = 4, CategoryName = "Birds" }
                );

            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, CategoryId = 1, Name = "Jimmy", Type = "Dog", Age = 4, ImageString = @"\Images\Animals\DogImg.jpeg", Description = "A dog is a domestic mammal of the family Canidae and the order Carnivora. Its scientific name is Canis lupus familiaris. Dogs are a subspecies of the gray wolf, and they are also related to foxes and jackals. Dogs are one of the two most ubiquitous and most popular domestic animals in the world. (Cats are the other.)"},
                new { AnimalId = 2, CategoryId = 1, Name = "Johnny", Type = "Cat", Age = 2, ImageString = @"\Images\Animals\CatImg.jpeg", Description = "A cat is a furry animal that has a long tail and sharp claws. Cats are often kept as pets. 2. countable noun. Cats are lions, tigers, and other wild animals in the same family." },
                new { AnimalId = 3, CategoryId = 3, Name = "Kasper", Type = "Discus", Age = 1, ImageString = @"\Images\Animals\DiscussImg.jpeg", Description = "Its body is very compressed on the sides, it has a disk-shaped profile and its fins are large and elegant. It is a species characterised by iridescence, streaks and vertical bands and can have different colours: white, yellow, orange, red, blue, blue and green, brown and black." },
                new { AnimalId = 4, CategoryId = 2, Name = "Kermit", Type = "Frog", Age = 9, ImageString = @"\Images\Animals\FrogImg.jpeg", Description = "In general, frogs have protruding eyes, no tail, and strong, webbed hind feet that are adapted for leaping and swimming. They also possess smooth, moist skins. Many are predominantly aquatic, but some live on land, in burrows, or in trees. A number depart from the typical form."},
                new { AnimalId = 5, CategoryId = 4, Name = "Abigail", Type = "Goose", Age = 4, ImageString = @"\Images\Animals\GooseImg.jpeg", Description = "A goose is a large bird with webbed feet. Geese hang out around ponds and lakes, fly in a V formation, and make a distinct honking noise. Geese are classified as waterfowl, birds that live at least part of the time in a body of water." },
                new { AnimalId = 6, CategoryId = 4, Name = "Mike", Type = "Chicken", Age = 2, ImageString = @"\Images\Animals\ChickenImg.jpeg", Description = "A chicken is a bird. One of the features that differentiate it from most other birds is that it has a comb and two wattles. The comb is the red appendage on the top of the head, and the wattles are the two appendages under the chin. These are secondary sexual characteristics and are more prominent in the male"  },
                new { AnimalId = 7, CategoryId = 4, Name = "Gardon", Type = "Duck", Age = 2, ImageString = @"\Images\Animals\DuckImg.jpeg", Description = "A chicken is a bird. One of the features that differentiate it from most other birds is that it has a comb and two wattles. The comb is the red appendage on the top of the head, and the wattles are the two appendages under the chin. These are secondary sexual characteristics and are more prominent in the male" },
                new { AnimalId = 8, CategoryId = 1, Name = "Buck", Type = "Weasel", Age = 1, ImageString = @"\Images\Animals\WeaselImg.jpeg", Description = "Along with their tubelike bodies, weasels have small flattened heads, long flexible necks, and short limbs. The fur is short but dense, and the slim tail is pointed at the tip. Five toes on each foot end in sharp curved claws. The species can be differentiated by size, colour, and relative length of the tail."},
                new { AnimalId = 9, CategoryId = 2, Name = "Dilen", Type = "Chameleon", Age = 3, ImageString = @"\Images\Animals\CamelionImg.jpeg", Description = "In the reptile world, there are some bizarre shapes and colors, but some of the most striking variations are found in the chameleons. These colorful lizards are known for their ability to change their color; their long, sticky tongue; and their eyes, which can be moved independently of each other."},
                new { AnimalId = 10, CategoryId = 3, Name = "Gup", Type = "Guppy", Age = 1, ImageString = @"\Images\Animals\GuppyImg.jpeg", Description = "The guppy is a small fish. Males are significantly smaller than females, measuring just 0.6-1.4 in (1.5-3.5 cm) long. Females, at about 1.2-2.4 in (3-6 cm) in length, are about twice the size. Males also tend to be more colorful, and extravagant, with ornamental fins absent in the females."},
                new { AnimalId = 11, CategoryId = 1, Name = "Chini", Type = "Chinchilla", Age = 1, ImageString = @"\Images\Animals\ChinchilaImg.jpeg", Description = "Chinchillas are closely related to porcupines a guinea pigs, with strong, muscular hind legs that resemble those of a rabbit. The chinchilla is a common exotic pet, but is also largely used in the fur industry for fashionable clothing. Wild chinchillas are only found in Chile, but historically lived in areas of Argentina, Peru and Bolivia. Read on to learn about the chinchilla."},
                new { AnimalId = 12, CategoryId = 1, Name = "Opi", Type = "Opossum", Age = 1, ImageString = @"\Images\Animals\OpussumImg.jpeg", Description = "The Possum comprises a group of marsupials that live in Australia, Sulawesi, and New Guinea. These furry creatures live in trees, and carry their young in a pouch. Many people incorrectly refer to “ oPossums ,” particularly the Virginia oPossum, as “Possums.” Researchers recognize approximately 70 different species of true Possums."},
                new { AnimalId = 13, CategoryId = 2, Name = "Gecki", Type = "Leopard Gecko", ImageString = @"\Images\Animals\GeckoLeopardImg.jpeg", Age = 1, Description = "Some geckos are not fond of being handled, but the Leopard Gecko is one of the tamest lizards you can own. Compared to other reptiles, they take less time to adapt to a new environment. As ground dwellers, Leopards do not need a vertical tank with branches, but they require a small enclosure with a substrate so they can burrow. The substrate should be made of recycled paper or reptile carpet. "},
                new { AnimalId = 14, CategoryId = 2, Name = "Chery", Type = "Bearded Dragon", ImageString = @"\Images\Animals\BeardedDragonImg.jpeg", Age = 1, Description = "This Australian native is light tan with a spiky “beard” around its neck that inflates when it feels threatened, but owners are unlikely to see the aggressive side of the docile creature. They tolerate handling well, and most are calm while they perch on their owner’s shoulder. "},
                new { AnimalId = 15, CategoryId = 3, Name = "Allen", Type = "Skalar", Age = 1, ImageString = @"\Images\Animals\SkalarImg.jpeg", Description = "hese extremely popular aquarium fish are very beautiful and effective creatures. They are also distinguished by a complex and interesting disposition, which, unfortunately, is sometimes underestimated."},
                new { AnimalId = 16, CategoryId = 4, Name = "Azmel", Type = "Eagle", Age = 1, ImageString = @"\Images\Animals\EagleImg.jpeg", Description = "Eagle is the common name for many large birds of prey of the family Accipitridae. Eagles belong to several groups of genera, some of which are closely related. Most of the 68species of eagle are from Eurasia and Africa.[1] Outside this area, just 14 species can be found—2 in North America, 9 in Central and South America, and 3 in Australia."}
                );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 13, Comments = "So cute!" },
                new { CommentId = 2, AnimalId = 13, Comments = "Adorable!" },
                new { CommentId = 3, AnimalId = 13, Comments = "Cool!" },
                new { CommentId = 4, AnimalId = 13, Comments = "Amazing!" },
                new { CommentId = 5, AnimalId = 8, Comments = "So cute!" },
                new { CommentId = 6, AnimalId = 8, Comments = "Amazing!" },
                new { CommentId = 7, AnimalId = 8, Comments = "Adorable!" },
                new { CommentId = 8, AnimalId = 8, Comments = "He is Beautiful!" },
                new { CommentId = 9, AnimalId = 1, Comments = "So cute!" },
                new { CommentId = 10, AnimalId = 1, Comments = "Cool!" },
                new { CommentId = 12, AnimalId = 15, Comments = "So cute!" },
                new { CommentId = 13, AnimalId = 9, Comments = "So cute!" },
                new { CommentId = 14, AnimalId = 13, Comments = "So cute!" },
                new { CommentId = 15, AnimalId = 4, Comments = "So cute!" },
                new { CommentId = 16, AnimalId = 9, Comments = "Amazing!" },
                new { CommentId = 17, AnimalId = 11, Comments = "So cute!" },
                new { CommentId = 18, AnimalId = 2, Comments = "Amazing!" },
                new { CommentId = 19, AnimalId = 2, Comments = "So cute!" }
                );

             modelBuilder.Entity<Login>().HasData(
                 new { Id = Guid.NewGuid(), UserName = "Danny", Password = "Daniel227@", isAdmin = true},
                 new { Id = Guid.NewGuid(), UserName = "Alex", Password = "Alex227@", isAdmin = false }
                );
        }
    }
}
