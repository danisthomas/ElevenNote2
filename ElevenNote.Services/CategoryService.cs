using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;
       

        public CategoryService(Guid userId)
        {
            _userId = userId;

        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    OwnerId = _userId,
                    CategoryName = model.CategoryName,
                    CategoryDesc = model.CategoryDesc

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
                
        }


        public IEnumerable<CategoryListItems> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Categories.Where(e => e.OwnerId == _userId)
                    .Select(e => new CategoryListItems
                    {
                        CategoryId = e.CategoryId,
                        CategoryName = e.CategoryName,
                        CategoryDesc = e.CategoryDesc
                    });
                return query.ToArray();
            }
        }

        public CategoryDetail GetCategorybyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == id && e.OwnerId == _userId);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName,
                        CategoryDesc = entity.CategoryDesc
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories
                    .Single(e => e.CategoryId == model.CategoryId && e.OwnerId == _userId);
                entity.CategoryName = model.CategoryName;
                entity.CategoryDesc = model.CategoryDesc;

                return ctx.SaveChanges() == 1;
                    
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories
                    .Single(e => e.CategoryId == categoryId && e.OwnerId == _userId);
                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
