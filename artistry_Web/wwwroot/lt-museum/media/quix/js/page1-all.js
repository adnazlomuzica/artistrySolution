jQuery(document).ready(function(){
	jQuery('#qx-filterable-gallery-871085 .qx-image--gallery').magnificPopup({
    type:'image',
    removalDelay: 500,
    mainClass: 'mfp-fade',
    gallery:{
      enabled:true,
      navigateByImgClick: true,
    },
    zoom: {
      enabled: true,
      duration: 500,
      opener: function(element) {
        return element.find('img');
      }
    }
  });
});;jQuery(document).ready(function(){
    var mySwiper = new Swiper ('#qx-carousel-58118', {
    slidesPerView: 4,slidesPerGroup: 1,spaceBetween: 30,autoplay:false,speed:5000,loop:false,navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev"
  },pagination: {
    el: ".swiper-pagination",
    clickable: true
  },breakpoints:{
    1024: { 
        slidesPerView: 4,  
        slidesPerGroup: 1,
        spaceBetween: 30
    },    
    768: { 
        slidesPerView: 4,  
        slidesPerGroup: 1,
        spaceBetween: 30
    },
    480: { 
        slidesPerView: 4,  
        slidesPerGroup: 1,
        spaceBetween: 30
    },
  }              
    });
});