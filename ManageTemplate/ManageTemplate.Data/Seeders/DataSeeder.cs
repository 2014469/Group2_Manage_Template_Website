using ManageTemplate.Core.Entities;
using ManageTemplate.Data.Contexts;

namespace ManageTemplate.Data.Seeders
{
  public class DataSeeder : IDataSeeder
  {
    private readonly TemplateDbContext _dbContext;

    public DataSeeder(
      TemplateDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Intitalize()
    {
      _dbContext.Database.EnsureCreated();

      if (_dbContext.Set<Section>().Any())
      {
        return;
      }

      var categories = AddCategories();
      var sections = AddSections(categories);
      var sampledDatas = AddSampledDatas(sections);
    }

    public IList<Category> AddCategories()
    {
      var categories = new List<Category>() {
        new Category(){
          Name="Header",
          Icon="view_quilt",
          UrlSlug="header",
          Description="Thanh tiêu đề",
          ShowOnMenu=true,
          Enable=true
        },
        new Category(){
          Name="Article",
          Icon="subject",
          UrlSlug="articale",
          Description="Đề mục",
          ShowOnMenu=true,
          Enable=true
        },
        new Category(){
          Name="Gallery",
          Icon="insert_photo",
          UrlSlug="gallery",
          Description="Thêm ảnh",
          ShowOnMenu=true,
          Enable=true
        },
        new Category(){
          Name="Ad",
          Icon="featured_video",
          UrlSlug="ad",
          Description="Quảng cáo",
          ShowOnMenu=true,
          Enable=true
        },
        new Category(){
          Name="Contact",
          Icon="table_chart",
          UrlSlug="contact",
          Description="Liên hệ",
          ShowOnMenu=true,
          Enable=true
        },

        new Category(){
          Name="Video",
          Icon="featured_video",
          UrlSlug="video",
          Description="Video",
          ShowOnMenu=true,
          Enable=true
        },
        new Category(){
          Name="Table Chart",
          Icon="view_agenda",
          UrlSlug="table-chart",
          Description="Biểu đồ bảng",
          ShowOnMenu=true,
          Enable=true
        },
      };



      var categoriesToAdd = new List<Category>();

      foreach (var category in categories)
      {
        if (!_dbContext.Categories.Any(c => c.UrlSlug == category.UrlSlug))
        {
          categoriesToAdd.Add(category);
        }
      }
      _dbContext.AddRange(categoriesToAdd);
      _dbContext.SaveChanges();

      return categories;
    }

    private IList<Section> AddSections(IList<Category> categories)
    {
      var sections = new List<Section>() {
        new Section()
        {
          Name = "Article 1",
          UrlSlug="article-1",
          PreviewImageUrl="https://i.imgur.com/6QUsWtK.png",
          Hbs="<div><div class='container'><div class='row'><div class='col-12'><h2 class='text-center'>{{title}}</h2><p class='text-center'>{{description}}</p></div></div><div class='row'><div class='col-sm-6 col-md-4 item'><a href='#'><img class='img-fluid' src='{{image1}}'/></a><h3 class='name'>{{articleTitle1}}</h3><p class='description'>{{text1}}</p></div><div class='col-sm-6 col-md-4 item'><a href='#'><img class='img-fluid' src='{{image2}}'/></a><h3 class='name'>{{articleTitle2}}</h3><p class='description'>{{text2}}</p></div><div class='col-sm-6 col-md-4 item'><a href='#'><img class='img-fluid' src='{{image3}}'/></a><h3 class='name'>{{articleTitle3}}</h3><p class='description'>{{text3}}</p></div></div></div></div>",
          Enable=true,
          Category=categories[1],
        },

        // article 2: Tien
        new Section()
        {
          Name = "Article 2",
          UrlSlug="article-2",
          PreviewImageUrl="https://i.imgur.com/xljS5RC.png",
          Hbs="<div><div class='container'><div class='row'><div class='col-12'><h2 class='text-center'>{{title}}</h2><p class='text-center'>{{description}}</p></div></div><div class='row'><div class='col-sm-6 col-md-4 item'><h3 class='name'>{{articleTitle1}}</h3><p class='description'>{{text1}}</p></div><div class='col-sm-6 col-md-4 item'><h3 class='name'>{{articleTitle2}}</h3><p class='description'>{{text2}}</p></div><div class='col-sm-6 col-md-4 item'><h3 class='name'>{{articleTitle3}}</h3><p class='description'>{{text3}}</p></div></div></div></div>",
          Enable=true,
          Category=categories[1],
        },
        // gallery 2: Tien
        new Section()
        {
          Name = "2 Column Gallery",
          UrlSlug="2-column-gallery",
          PreviewImageUrl="https://i.imgur.com/3hpsgRt.png",
          Hbs="<div class='container'> <div class='row'> <div class='col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img1}}' alt='{{alt1}}'> </a> </div> <div class='col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img2}}' alt='{{alt2}}'> </a> </div> </div> </div>",
          Enable=true,
          Category=categories[2],
        },
        // navbar: Tien
        new Section()
        {
          Name = "Navbar 1",
          UrlSlug="navbar",
          PreviewImageUrl="https://i.imgur.com/awrvf3d.png",
          Hbs="<nav class='navbar navbar-expand-lg navbar-light {{#if useDarkTheme}}navbar-dark bg-dark{{else}}bg-light{{/if}}'> <a class='navbar-brand' href='#'>{{brand}}</a> <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbar' aria-controls='navbar' aria-expanded='false' aria-label='Toggle navigation'> <span class='navbar-toggler-icon'></span> </button> <div class='collapse navbar-collapse' id='navbar'> <ul class='navbar-nav mr-auto'> <li class='nav-item active'> <a class='nav-link' href='#'>{{link1}} <span class='sr-only'>(current)</span> </a> </li> <li class='nav-item'> <a class='nav-link' href='#'>{{link2}}</a> </li> <li class='nav-item'> <a class='nav-link' href='#'>{{link3}}</a> </li> <li class='nav-item'> <a class='nav-link' href='#'>{{link4}}</a> </li> </ul> {{#if showSearch}} <form class='form-inline my-2 my-lg-0'> <input class='form-control mr-sm-2' type='text' placeholder='Search'> <button class='btn btn-secondary my-2 my-sm-0' type='submit'>Search</button> </form> {{/if}} </div> </nav>",
          Enable=true,
          Category=categories[0],
        },
        // gallery3 : Hung
        new Section()
        {
          Name = "3 column gallery",
          UrlSlug="3-column-gallery",
          PreviewImageUrl= "https://i.imgur.com/L0eQWAp.png",
          Hbs="<div class='container'> <div class='row'> <div class='col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img1}}' alt='{{alt1}}'> </a> </div> <div class='col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img2}}' alt='{{alt2}}'> </a> </div> <div class='col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img3}}' alt='{{alt3}}'> </a> </div> </div> </div>",
          Enable=true,
          Category=categories[2],
        },
        // gallery4: Hung
         new Section()
        {
          Name = "4 column gallery",
          UrlSlug="4-column-gallery",
          PreviewImageUrl= "https://i.imgur.com/jFFAd28.png",
          Hbs="<div class='container'> <div class='row'> <div class='col-lg-3 col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img1}}' alt='{{alt1}}'> </a> </div> <div class='col-lg-3 col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img2}}' alt='{{alt2}}'> </a> </div> <div class='col-lg-3 col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img3}}' alt='{{alt3}}'> </a> </div> <div class='col-lg-3 col-md-4 col-6'> <a href='#' class='d-block mb-4 h-100'> <img class='img-fluid img-thumbnail' src='{{img4}}' alt='{{alt4}}'> </a> </div> </div> </div>",
          Enable=true,
          Category=categories[2],
        },
       
        // header1: Duat
        new Section()
        {
          Name = "Simple Header #1",
          UrlSlug="simple-header-1",
          PreviewImageUrl="https://i.imgur.com/IXz7LZ5.png",
          Hbs="<div class='container text-center pt-5 pb-5'><h5>{{title}}</h5><h1 class='display-4'>{{tagline}}</h1><a class='btn btn-link' href='#'>{{link}}</a></div>",
          Enable=true,
          Category=categories[0],
        },
        // header2: Duat
        new Section()
        {
          Name = "Simple Header #2",
          UrlSlug="simple-header-2",
          PreviewImageUrl="https://i.imgur.com/1bYEKB4.png",
          Hbs="<div class='jumbotron m-0'><div class='container text-center'><h1 class='display-4'>{{title}}</h1><p class='lead text-muted'>{{tagline}}</p><a class='btn btn-primary my-2' href='#'>{{button}}</a><a class='btn btn-link my-2' href='#'>{{link}}</a></div></div>",
          Enable=true,
          Category=categories[0],
        },
      };


      var sectionsToAdd = new List<Section>();

      foreach (var section in sections)
      {
        if (!_dbContext.Sections.Any(c => c.UrlSlug == section.UrlSlug))
        {
          sectionsToAdd.Add(section);
        }
      }
      _dbContext.AddRange(sectionsToAdd);
      _dbContext.SaveChanges();

      return sections;
    }

    private IList<SampledData> AddSampledDatas(IList<Section> sections)
    {
      var sampledDatas = new List<SampledData>() {
          //article1 : Long
          new SampledData()
          {
            Name="title",
            Data="Sample section",
            Type="string",
            Title="Section title",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="description",
            Data="Lorem ipsum dolor sit amet.",
            Type="string",
            Title="Section description",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="image1",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #1",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="image2",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #2",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="image3",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #3",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="articleTitle1",
            Data="Hello world",
            Type="string",
            Title="Title for the article #1",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="articleTitle2",
            Data="Hello world",
            Type="string",
            Title="Title for the article #2",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="articleTitle3",
            Data="Hello world",
            Type="string",
            Title="Title for the article #3",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="text1",
            Data="Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, interdum justo suscipit id.",
            Type="string",
            Title="Content for the article #1",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="text2",
            Data="Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, interdum justo suscipit id.",
            Type="string",
            Title="Content for the article #2",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="text3",
            Data="Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, interdum justo suscipit id.",
            Type="string",
            Title="Content for the article #3",
            Section=sections[0]
          },
          // article 2: long
          new SampledData()
          {
            Name="title",
            Data="Sample section",
            Type="string",
            Title="Section title",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="description",
            Data="Lorem ipsum dolor sit amet.",
            Type="string",
            Title="Section description",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="articleTitle1",
            Data="Hello World",
            Type="string",
            Title="Title for the article #1",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="articleTitle2",
            Data="Hello world",
            Type="string",
            Title="Title for the article #2",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="articleTitle3",
            Data="Hello world",
            Type="string",
            Title="Title for the article #3",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="text1",
            Data="Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, interdum justo suscipit id.",
            Type="string",
            Title="Content for the article #1",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="text2",
            Data="Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, interdum justo suscipit id.",
            Type="string",
            Title="Content for the article #2",
            Section=sections[0]
          },
          new SampledData()
          {
            Name="text3",
            Data="Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu gravida. Aliquam varius finibus est, interdum justo suscipit id.",
            Type="string",
            Title="Content for the article #3",
            Section=sections[0]
          },
          // gallery2: Tien
          new SampledData()
          {
            Name="img1",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #1",
            Section=sections[2]
          },
          new SampledData()
          {
            Name="img2",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #2",
            Section=sections[2]
          },
          new SampledData()
          {
            Name="alt1",
            Data="Sample image",
            Type="string",
            Title="Alt for image #1",
            Section=sections[2]
          },
          new SampledData()
          {
            Name="alt2",
            Data="Sample image",
            Type="string",
            Title="Alt for image #2",
            Section=sections[2]
          },
          // gallery3: Tien
          new SampledData()
          {
            Name="img1",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #1",
            Section=sections[4]
          },
          new SampledData()
          {
            Name="img2",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #2",
            Section=sections[4]
          },
          new SampledData()
          {
            Name="img3",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #3",
            Section=sections[4]
          },
          new SampledData()
          {
            Name="alt1",
            Data="Sample image",
            Type="string",
            Title="Alt for image #1",
            Section=sections[4]
          },
          new SampledData()
          {
            Name="alt2",
            Data="Sample image",
            Type="string",
            Title="Alt for image #2",
            Section=sections[4]
          },
          new SampledData()
          {
            Name="alt3",
            Data="Sample image",
            Type="string",
            Title="Alt for image #3",
            Section=sections[4]
          },
          // gallery4: Hung
          
          new SampledData()
          {
            Name="img1",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #1",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="img2",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #2",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="img3",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #3",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="img4",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Url to image #4",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="alt1",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Alt to image #1",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="alt2",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Alt to image #2",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="alt3",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Alt to image #3",
            Section=sections[5]
          },
          new SampledData()
          {
            Name="alt4",
            Data="https://via.placeholder.com/450x450",
            Type="string",
            Title="Alt to image #4",
            Section=sections[5]
          },
          //header1: Hung
               new SampledData()
          {
            Name="title",
            Data="Hello World",
            Type="string",
            Title="Title",
            Section=sections[6]
          },
                    new SampledData()
          {
            Name="tagline",
            Data="Lorem ipsum dolor sit amet.",
            Type="string",
            Title="Tag Line",
            Section=sections[6]
          },
                    new SampledData()
          {
            Name="link",
            Data="Read more",
            Type="string",
            Title="Text on the link",
            Section=sections[6]
          },   

          // header2: Duat 
          new SampledData()
          {
            Name="title",
            Data="Hello World",
            Type="string",
            Title="Title",
            Section=sections[7]
          },
          new SampledData()
          {
            Name="tagline",
            Data="Lorem ipsum dolor sit amet.",
            Type="string",
            Title="Tag Line",
            Section=sections[7]
          },
          new SampledData()
          {
            Name="button",
            Data="Click here",
            Type="string",
            Title="Text on the button",
            Section=sections[7]
          },
          new SampledData()
          {
            Name="link",
            Data="Read more",
            Type="string",
            Title="Text on the link",
            Section=sections[7]
          },
          // navbar1: Duat
          new SampledData()
          {
            Name="brand",
            Data="Reynholm",
            Type="string",
            Title="Brand name",
            Section=sections[3]
          },
          new SampledData()
          {
            Name="link1",
            Data="Home",
            Type="string",
            Title="Link #1",
            Section=sections[3]
          },
          new SampledData()
          {
            Name="link2",
            Data="Feature",
            Type="string",
            Title="Link #2",
            Section=sections[3]
          },
          new SampledData()
          {
            Name="link3",
            Data="Pricing",
            Type="string",
            Title="Link #3",
            Section=sections[3]
          },
          new SampledData()
          {
            Name="link4",
            Data="About",
            Type="string",
            Title="Link #4",
            Section=sections[3]
          },
          new SampledData()
          {
            Name="showSearch",
            Data="1",
            Type="boolean",
            Title="Show search",
            Section=sections[3]
          },
          new SampledData()
          {
            Name="useDarkTheme",
            Data="0",
            Type="boolean",
            Title="Use dark theme",
            Section=sections[3]
          },
        };

      if (!_dbContext.SampledDatas.Any())
      {
        _dbContext.AddRange(sampledDatas);
        _dbContext.SaveChanges();
      }

      return sampledDatas;
    }

  }
}
