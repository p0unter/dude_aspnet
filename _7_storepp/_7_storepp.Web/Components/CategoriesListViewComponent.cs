using Microsoft.AspNetCore.Mvc;
using _7_storepp.Data.Abstract;
using _7_storepp.Web.Models;

namespace _7_storepp.Web.Components;

public class CategoriesListViewComponent:ViewComponent
{
    private readonly IStoreRepository _storeRepository;
    public CategoriesListViewComponent(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(_storeRepository.Categories.Select(c => new CategoryViewModel {
            Id = c.Id,
            Name = c.Name,
            Url = c.Url
        }).ToList());
    }
}