using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _7_storepp.Data.Abstract;
using _7_storepp.Web.Models;

namespace _7_storepp.Web.Controllers;
public class HomeController :Controller
{
    public int pageSize = 3;
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    public HomeController(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    public IActionResult Index(string category, int page = 1) 
    {
        return View(new ProductListViewModel {
            Products = _storeRepository.GetProductsByCategory(category, page, pageSize)
                .Select(product => _mapper.Map<ProductViewModel>(product)),
            PageInfo = new PageInfo {
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = _storeRepository.GetProductCount(category)
            }
        });

    }
}