document.getElementById('addClassroom').addEventListener('click', function () {
    var select = document.getElementById('classrooms');
    var classrooms = document.getElementById('selectedClassrooms');
    var selectedOption = select.options[select.selectedIndex];
    var div = document.createElement('div');
    div.className = 'card col-3 m-2';
    var img = document.createElement('img');
    img.src = selectedOption.getAttribute('data-img');
    img.className = 'card-img-top';
    var cardBody = document.createElement('div');
    cardBody.className = 'card-body';
    var h5 = document.createElement('h5');
    h5.textContent = selectedOption.text;
    h5.className = 'card-title';
    var p = document.createElement('p');
    p.textContent = 'Age Range: ' + selectedOption.getAttribute('data-min-age') + '-' + selectedOption.getAttribute('data-max-age');
    p.className = 'card-text';
    var button = document.createElement('button');
    button.textContent = 'Remove';
    button.className = 'btn btn-danger';
    button.addEventListener('click', function () {
        // Remove this classroom when clicked
        classrooms.removeChild(div);
    });
    cardBody.appendChild(h5);
    cardBody.appendChild(p);
    cardBody.appendChild(button);
    div.appendChild(img);
    div.appendChild(cardBody);
    classrooms.appendChild(div);

    //new stuff:
    var hiddenField = document.createElement('input');
    hiddenField.type = 'hidden';
    hiddenField.name = 'classroomIds';
    hiddenField.value = selectedOption.value;
    hiddenFields.appendChild(hiddenField);

});