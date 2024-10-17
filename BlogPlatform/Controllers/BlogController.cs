using BlogPlatform.DAL;
using BlogPlatform.Helper;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogPlatform.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var posts = from p in _context.BlogPosts select p;

            // Search by title or post date
            if (!string.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(s => s.Title.Contains(searchString) || s.PostDate.ToString().Contains(searchString));
            }
        
              int pageSize = 10;
            return View(await PaginatedList<BlogPost>.CreateAsync(posts.AsNoTracking(), page, pageSize));
        }
        // GET: Blog/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: Blog/Create (Show the form to create a new blog post)
        public IActionResult Create()
    {
        return View();
    }

    // POST: Blog/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Content,PostDate")] BlogPost blogPost)
    {
        if (ModelState.IsValid)
        {
            _context.Add(blogPost);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Blog post created successfully!"; 
           return RedirectToAction(nameof(Index));
        }
        return View(blogPost);
    }


        // GET: Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,PostDate")] BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Blog post updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost); // Pass the blogPost model to the Delete view
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost); 
                await _context.SaveChangesAsync(); 
                TempData["SuccessMessage"] = "Blog post deleted successfully!"; 
            }

            return RedirectToAction(nameof(Index)); 
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }
    }
}

