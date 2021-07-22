﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;
namespace CodingEvents.Controllers
{
    
    public class EventsController : Controller
    {
        //private static List<string> Events = new List<string>();

        /*private static List<Event> Events = new List<Event>();*/

        [HttpGet]
        public IActionResult Index()
        {


            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet] 
        // /events/add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/events/add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int i in eventIds)
            {
                EventData.Remove(i);
            }
            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId?}")]
        public IActionResult Edit(int eventId, string name)
        {
            ViewBag.eventToBeEdited = EventData.GetById(eventId);
            ViewBag.EditEvent = $"Edit Event {name} (id={eventId})";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit/{eventId?}")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData.Events[eventId].Name = name;
            EventData.Events[eventId].Description = description;
            
            return Redirect("/Events");
        }
    }
}
