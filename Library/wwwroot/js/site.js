// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function initRemoveModal() {
    const modalElement = document.querySelector('#removeBookModal');
    const confirmElement = document.querySelector('#removeBookModalButton');
    const trigger = document.querySelector('#removeBookButton');
    
    if (!modalElement || !trigger || !confirmElement) {
        return;
    }

    const modal = new bootstrap.Modal(modalElement)

    trigger.addEventListener('click', e => {
        const bookId = e.currentTarget.parentElement.parentElement.dataset.bookId || null;
        
        if (!bookId) {
            return;
        }

        confirmElement.href = '/Book/Remove/' + bookId;

        modal.show();
    });
}

document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('[data-bs-toggle="popover"]')
        .forEach(e => new bootstrap.Popover(e));

    initRemoveModal();
})
