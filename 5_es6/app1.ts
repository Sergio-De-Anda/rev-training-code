import { Marvel } from './marvel1';

let literalobject = {
  name: 'fred',
  topic: 'es6'
}


function startup () {
  let m:any = new Marvel();

  m.name = 'Captain America';
  m.origin = 'Brooklyn, NY';
  m.power = 'Super Soldier';

  console.log(m);
}

// ajax
function starwars (response:any) {
  console.log(response);
}

function ajax() {
  let xhr = new XMLHttpRequest();

  xhr.open('GET', 'https://swapi.co/api/people/1');
  xhr.onreadystatechange = function () {
    if (xhr.status == 200 && xhr.readyState == 4) {
      starwars(xhr.response);
    }
  }
  xhr.send();
}
// fetchy
function pass(res:any) {
  console.log( res.json().then(function (data:any) {
    console.log(data);
  }));
}

function fetchy() {
  fetch('https://swapi.co/api/people/1').then(pass, function(res) {
    console.error(res);
  });
}
// fetchy async
async function passAsync(res:any) {
  let data = await res.json();
  console.log(data);
}

async function fetchyAsync() {
  var res = await fetch('https://swapi.co/api/people/1');
  passAsync(res);
}

// run function
(function (func) {
  func();
})(fetchyAsync);