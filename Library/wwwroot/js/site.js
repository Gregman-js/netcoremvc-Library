// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function initRemoveModal() {
    const modalElement = document.querySelector('#removeModal');
    const confirmElement = document.querySelector('#removeModalButton');
    const trigger = document.querySelector('#removeButton');
    
    if (!modalElement || !trigger || !confirmElement) {
        return;
    }

    const modal = new bootstrap.Modal(modalElement)

    trigger.addEventListener('click', e => {
        const modelId = e.currentTarget.parentElement.parentElement.dataset.modelId || null;
        
        if (!modelId) {
            return;
        }

        confirmElement.href = '/Book/Remove/' + modelId;

        modal.show();
    });
}

document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('[data-bs-toggle="popover"]')
        .forEach(e => new bootstrap.Popover(e));

    initRemoveModal();
})
