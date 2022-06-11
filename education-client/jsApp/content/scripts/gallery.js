'use strict';

const gallery = document.querySelector('.gallery-wrapper');
const baseUrl = "https://localhost:7212/api/v1/courses";
const dropdownContent = document.querySelector('#dropdownList');
const categories = [];
const courses = [];

const listCoursesByCategory = () => {
  var selectedValue = document.querySelector('#dropdownList').selectedIndex;
  gallery.innerHTML = "";
  courses.forEach((course) => {
    if (course.category === categories[selectedValue]){
      gallery.insertAdjacentHTML(
        'beforeend',
        `<div class="gallery-card">
          <h4>${course.courseTitle}</h4>
          <img src="${course.imgURL}" id="${course.courseNr}" width="400"/>
          <div class="card-info">
            <div class="card-info-data">Kursnr: ${course.courseNr}</div>
            <div class="card-info-data">Kurslängd: ${course.length}</div>
          </div>
        </div>`
        );
    }
  })
  console.log(courses);
  loadImages();
}

const loadImages = () => {
  const images = document.querySelectorAll('.gallery-card img');
  images.forEach((image) => {
    let appUrl = image.baseURI.endsWith('#') ?
    image.baseURI.slice(0, -1) :
    image.baseURI;
    

    let src = image.getAttribute('src');
    let id = image.getAttribute('id');
    let url = `coursedetails.html?courseNr=${id}`;

    image.addEventListener('click', () =>{
      //console.log(`Du klickade... id: ${id} src: ${src} url:${url} `);
      window.location = `${url}`;
    });
  });
  console.log(images);
};

const getCourses = async() =>{
  const url = `${baseUrl}/list`;
  const response = await fetch(url);
  console.log(response);
  if(!response.ok){
    console.log("Något gick fel...");
  }
  const getCourses = await response.json();
  console.log(getCourses);
  getCourses.forEach((course) => {
    const category = course.category;
    if (!categories.includes(category)){
      categories.push(category);
      dropdownContent.insertAdjacentHTML('beforeend',`<option value="${category}">${category}</option>`)
    }
    courses.push(course);
  });
}

getCourses();