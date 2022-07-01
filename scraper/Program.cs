// books.toscrape.com

// Scraping exercise:
// STEP 1. Get all links
// STEP 2. Process all links to get book details
// STEP 3. Export CSV

// get the page
// get an object of that page - this is parsing
// get exactly the information you are looking for - querying
// (we'll be looking for booktitle and price)
// CSV (in real life it'll be a db)


using HtmlAgilityPack;
using scraper;

string url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html";

// get all the book links
var links = GetBookLinks(url);

List<Book> books = GetBooks(links);


// a method for getting the document
static HtmlDocument GetDocument(string url)
{
    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load(url);
    return doc;
}


// get the page as an HtmlDocument
HtmlDocument doc = GetDocument(url);

// now we want to extract all the links from that page
// so we make a function for that that returns a list of strings
static List<string> GetBookLinks(string url)
{
    HtmlDocument doc = GetDocument(url);
    var linkNodes = doc.DocumentNode.SelectNodes("//h3/a"); //selects all the nodes that match this XPath

    Uri baseUri = new Uri(url); //we create a new Uri object
    Console.WriteLine("base uri: " + baseUri.ToString());
    var links = new List<string>();

    // run a loop over linkNodes to select the links
    foreach (var node in linkNodes)
    {
       var link = node.Attributes["href"].Value; // this is relative url (../../../its-only-the-himalayas_981/index.html) , we need to convert it to absolute url
       // override the link with absolute path
       link = new Uri(baseUri, link).AbsoluteUri; // different constructor is used for this; use AbsoluteUri to make it a string with an absolute Uri, not Uri type
       links.Add(link);
    }
    return links;
}
















