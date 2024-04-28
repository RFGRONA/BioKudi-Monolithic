// Check if the page has already been reloaded
if (!sessionStorage.getItem('reloaded')) {
    // If it has not been reloaded, reload it
    sessionStorage.setItem('reloaded', 'true');
    window.location.reload();
} else {
    // If it has already been reloaded, clear the session variable for next time
    sessionStorage.removeItem('reloaded');
}