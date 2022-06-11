'use strict';

const courseinfo = document.querySelector('.course-info');
const pageTitle = document.querySelector('.page-title');
const courseTitle = document.querySelector('#courseTitle');
const length = document.querySelector('#length');
const category = document.querySelector('#category');
const description = document.querySelector('#description');
const details = document.querySelector('#details');
const imgURL = document.querySelector('.courseImage');

const baseUrl = "https://localhost:7212/api/v1/courses";

const pageLoad = async () => {
  const urlParams = new URLSearchParams(location.search);

  let courseNr = 0;
  for (let [key, value] of urlParams){
    if (key === 'courseNr'){
      courseNr = value;
    }
  }
  let course = await getCourse(courseNr);
  createHtml(course);
};

const getCourse = async (courseNr) => {
  const url = `${baseUrl}/nr/${courseNr}`;
  const response = await fetch(url);
  if(!response.ok){
    console.log('Kunde inte hämta kursen...');
  }
  const course = await response.json();
  return course;
};

const createHtml = (course) => {
  pageTitle.innerHTML = course.courseTitle;
  courseTitle.innerHTML = course.courseTitle;
  imgURL.src = course.imgURL;
  length.innerHTML = course.length;
  category.innerHTML = course.category;
  description.innerHTML = course.description;
  details.innerHTML = course.details;
  //courseTitle.insertAdjacentHTML('beforeend',`: ${course.courseTitle}`);
};


pageLoad();