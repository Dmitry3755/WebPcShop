import { Component } from "react";
import {Modal, Button} from '@material-ui/core'
import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    class: {
        alignItems: 'center',
        justifyContent: 'center',
        transform: 'translate(-50%, -50%)',
        position: 'absolute',
        left: '50%',
        top: '50%',
        
        backgroundColor: theme.palette.background.paper,
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
    },
    select: {
        width: "50%",
    }
}));

function updatePhysicalPerson(physicalPerson) {
console.log(physicalPerson.physical_person_id);
    fetch("http://localhost:36964/api/PhysicalPerson/"+physicalPerson.physical_person_id,
    {
        method:'PUT',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        credentials: 'include',
        body:JSON.stringify({

            physical_person_id: physicalPerson.physical_person_id,
            physical_person_name: physicalPerson.physical_person_name,
            physical_person_pasport_number: physicalPerson.physical_person_pasport_number,
            physical_person_TIN: physicalPerson.physical_person_TIN,
        })
    })
    .then(response=>{response.json()})
}

const EditedPhysicalPersonsModel = ({EditedPhysicalPersons}) => {
    
    const [physical_person_id, setPhysicalPersonsId] = useState(EditedPhysicalPersons.physical_person_id);
    const [physical_person_name, setPhysicalPersonsName] = useState(EditedPhysicalPersons.physical_person_name);
    const [physical_person_pasport_number, setLegalPersonPasportNumber] = useState(EditedPhysicalPersons.physical_person_pasport_number);
    const [physical_person_TIN, setPhysicalPersonsTIN] = useState(EditedPhysicalPersons.physical_person_TIN);
    const classes = useStyles();
    const [open, setOpen] = React.useState(false); 

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    const onSubmit = event => {
        event.preventDefault();
    }


    return(
            <div>
            <Button variant="outlined" color="primary" onClick={handleOpen}>Изменить</Button>

            <Modal open={open}
            onClose={handleClose}>   
                  
                <div className={classes.class}>
                <h2>Редактировать Физ. лицо</h2><br />    
                    <form >
                        <input type="text" name="physical_person_id" hidden />
                        <div className="form1_div">ФИО</div><input type="text" required name="physical_person_name"  value={physical_person_name} onChange={e=>(setPhysicalPersonsName(e.target.value))} placeholder="Введите ФИО" className="form1_input" /> <br />
                        <div className="form1_div">Серия, номер паспорта</div><input type="text" required name="physical_person_pasport_number"  value={physical_person_pasport_number} onChange={e=>(setLegalPersonPasportNumber(e.target.value))} placeholder="Введите КПП" className="form1_input" /> <br />
                        <div className="form1_div">ИНН</div><input type="text" required name="physical_person_TIN"  value={physical_person_TIN} onChange={e=>(setPhysicalPersonsTIN(e.target.value))} placeholder="Введите ОГРН" className="form1_input" /> <br />
                        <input id="create_button" type="submit" value="Применить" onClick={(e)=>{updatePhysicalPerson({physical_person_id, physical_person_name, physical_person_pasport_number, physical_person_TIN}); return false;}} />
                        <br />
                    </form>
                </div>
            </Modal>
            </div>
        )
}
export default EditedPhysicalPersonsModel
