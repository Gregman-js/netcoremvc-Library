// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function initRemoveModal() {
    const modalElement = document.querySelector('#removeModal');
    const confirmElement = document.querySelector('#removeModalButton');
    const trigger = document.querySelectorAll('#removeButton');
    
    if (!modalElement || !trigger.length || !confirmElement) {
        return;
    }

    const modal = new bootstrap.Modal(modalElement)

    trigger.forEach(el => el.addEventListener('click', e => {
        const modelId = e.currentTarget.dataset.modelId || e.currentTarget.parentElement.parentElement.dataset.modelId || null;

        if (!modelId) {
            return;
        }

        confirmElement.href = '/Book/Remove/' + modelId;

        modal.show();
    }));
}

function initTooltips() {
    document.querySelectorAll('[data-bs-toggle="tooltip"]')
        .forEach(el => new bootstrap.Tooltip(el));
}

document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('[data-bs-toggle="popover"]')
        .forEach(el => new bootstrap.Popover(el));

    initRemoveModal();
    initTooltips();
})
