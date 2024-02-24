function isElementInViewport(el) {
    var rect = el.getBoundingClientRect();
    return (
        rect.top >= 0 &&
        rect.left >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
        rect.right <= (window.innerWidth || document.documentElement.clientWidth)
    );
}
function checkAnimations() {
    var elements = document.querySelectorAll('.imageDiv,.imageDiv1, .textDiv');

    elements.forEach(function(el) {
        var rect = el.getBoundingClientRect();
        var distanceFromTop = rect.top;
        var distanceFromBottom = rect.bottom;

        // Calculate opacity based on distance from the top and bottom of imageDiv
        var opacity = 0;
        if (distanceFromTop <= 0 && distanceFromBottom >= 0) {
            // Element is in the viewport
            opacity = 1;
        } else if (distanceFromTop < 0) {
            // Element is above the viewport
            opacity = 1 + distanceFromTop / rect.height;
        } else {
            // Element is below the viewport
            opacity = 1 - distanceFromTop / window.innerHeight;
        }

        // Clamp opacity between 0 and 1
        opacity = Math.min(1, Math.max(0, opacity));

        // Apply opacity
        el.style.opacity = opacity;
    });
}

window.addEventListener('scroll', function() {
    checkAnimations();
});

// Initial check
checkAnimations();
