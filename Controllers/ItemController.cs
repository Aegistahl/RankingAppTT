using Microsoft.AspNetCore.Mvc;
using RankingAppTT.Models;
using RankingAppTT.Data;
using Microsoft.EntityFrameworkCore;
using RankingAppTT.DAL;
using RankingAppTT.ViewModel;
using AutoMapper;
using System.Data;



namespace RankingAppTT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {

        private readonly IMapper _mapper;
        private IItemRepository _itemRepository;


        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create(ItemModel item)
        {
            _itemRepository.InsertItem(item);
            _itemRepository.Save();

            return RedirectToAction("Index");
        }

        

        [HttpGet("{id}")]
        public ActionResult GetItemById(int id)
      {
         var item = _itemRepository.GetItemByID(id);
            if (item == null)
            {
                return NotFound();
            }

         var result = _mapper.Map<ItemViewModel>(item);


         return View(result);
      }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
      {
         try
         {
            ItemModel item = _itemRepository.GetItemByID(id);
            _itemRepository.DeleteItem(id);
            _itemRepository.Save();
         }
         catch (DataException)
         {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
         }
         return RedirectToAction("Index");
      }

        

        [HttpGet]
        public IActionResult Index()
        {
            var items = _itemRepository.GetItems();
            var itemViewModel = _mapper.Map<IEnumerable<ItemViewModel>>(items);
            return View(itemViewModel);
            
            
        }


        


        

        


    }

}

