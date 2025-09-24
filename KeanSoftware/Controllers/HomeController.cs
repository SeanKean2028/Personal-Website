using KeanSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System;
using System.IO;

namespace KeanSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Blog1()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }
        public IActionResult GameDevelopment()
        {
            return View();
        }
        public IActionResult Link(string _link, string _linkName, int _x, int _y)
        {
            Link returnLink = new Link(_link, _linkName, _x, _y);
            return View(returnLink);
        }
        public IActionResult Lesson(string _title)
        {
            //Title and Directory
            string title = _title;
            string directoryPath = @"wwwroot\\Lessons\\" + _title;

            // Get and parse all filenames
            string lines = System.IO.File.ReadAllText(directoryPath + @"\\" + "Manifest.txt");
            string[] split_arr = lines.Split('\n');
            List<string> files = new List<string>();
            List<string> newFileContents = new List<string>();
            foreach (string l in split_arr){
                string realL = "";
                if (l.ToCharArray()[l.ToCharArray().Length - 1] != 't')
                    realL = l.Remove(l.Length - 1);
                else
                    realL = l;
                files.Add(directoryPath + @"\\" + l);
                Debug.WriteLine(realL);
                using (StreamReader sr = new StreamReader(@"wwwroot\\Lessons\\" + _title + @"\\" + realL)){
                    newFileContents.Add(sr.ReadToEnd());
                }
            }
            List<string> newFileNames = new List<string>();
            foreach (string _string in files)
            {
                newFileNames.Add(Name(_string));

            }
            //Get Description
            string description = System.IO.File.ReadAllText(@"wwwroot\\Lessons\\" + _title + @"\\Description.txt");

            Lesson2 lesson = new Lesson2(title, newFileNames.ToArray(), description, newFileContents.ToArray());
            return View(lesson);
        }
        string Name(string _fileName)
        {
            char[] chars = _fileName.ToCharArray();
            string newfile = "";
            bool stop = false;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '.')
                    stop = true;
                if(i > 27 && stop == false)
                {
                    newfile += chars[i];
                }
            }
            return newfile;

        }
        public IActionResult Unit(string _title)
        {
            string title = _title;
            return View(_title);
        }
        public IActionResult GameDevLessons()
        {
            List<string> allfiles =  new List<string>();
            List<string> unparsedFiles =  new List<string>();
            List<string> descriptions = new List<string>();
            TempData["title"] = "";

            string path = @"wwwroot\\Lessons\\";

            if (Directory.Exists(path))
            {
                string[] directories = Directory.GetDirectories(path);

                foreach (string directory in directories)
                {
                    unparsedFiles.Add(directory);
                    if(System.IO.File.Exists(directory + @"\Description.txt"))
                    {
                        string all = System.IO.File.ReadAllText(directory + @"\Description.txt");
                        descriptions.Add(all);
                    }
                    allfiles.Add(parsedName(directory));
                }
            }
            Lessons gameDevLessons = new Lessons(allfiles.ToArray(), descriptions.ToArray());
            return View(gameDevLessons);
        }

        private string parsedName(string _string)
        {
            int l = 0;
            string _paresedName = "";
            foreach(char _char in _string)
            {

                if (_char == 'L')
                    l++;
                if (l == 2){
                    _paresedName += _char;

                }
            }
            return _paresedName;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

