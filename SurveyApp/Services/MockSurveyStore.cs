using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Models;

namespace SurveyApp.Services
{
    /// <summary>
    /// Mock data store for surveys. This is used for testing without the survey
    /// </summary>
    public class MockSurveyStore : IDataStore<Survey>
    {
        List<Survey> _items;

        public MockSurveyStore()
        {
            _items = new List<Survey>();
            var items = new List<Survey>
            {
                new Survey(){
                    Title = "Survey 1",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 2",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 3",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 4",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 5",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 6",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 7",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 8",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
                new Survey(){
                    Title = "Survey 9",
                    Description = "This is a test survey with a single question and multiple options",
                    Question = "What is the answer?",
                    Options = new List<string>{ "Option 1", "Option 2", "Option 3", "Option 4"}
                },
            };

            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Survey item)
        {
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Survey item)
        {
            var existingItem = _items.FirstOrDefault((i) => i.Id == item.Id);
            _items.Remove(existingItem);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = _items.Where((arg) => arg.Id == id).FirstOrDefault();
            _items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Survey> GetItemAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Survey>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}
