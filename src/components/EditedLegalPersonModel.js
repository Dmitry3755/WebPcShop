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

function updateLegalPerson(legalPerson) {

    fetch("http://localhost:36964/api/LegalPerson/"+legalPerson.legal_person_id,
    {
        method:'PUT',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        credentials: 'include',
        body:JSON.stringify({

            legal_person_id: legalPerson.legal_person_id,
            Legal_person_TIN: legalPerson.Legal_person_TIN,
            Legal_person_CRS: legalPerson.Legal_person_CRS,
            Legal_person_MSRN: legalPerson.Legal_person_MSRN,
        })
    })
    .then(response=>{response.json()})
}

const EditedLegalPersonModel = ({EditedLegalPerson}) => {
    
    const [legalPersons, setLegalPerson] = useState([]);
    const [legal_person_id, setLegalPersonId] = useState(EditedLegalPerson.legal_person_id);
    const [Legal_person_TIN, setLegalPersonTIN] = useState(EditedLegalPerson.Legal_person_TIN);
    const [Legal_person_CRS, setLegalPersonCRS] = useState(EditedLegalPerson.Legal_person_CRS);
    const [Legal_person_MSRN, setLegalPersonMSRN] = useState(EditedLegalPerson.Legal_person_MSRN);
    const classes = useStyles();
    const [open, setOpen] = React.useState(false);

    const getLegalPerson = () => {
        fetch("http://localhost:36964/api/LegalPerson/", {
            headers : {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json',
            },
            credentials: 'include'
        })
            .then(response => response.json())
            .then(data => {
                setLegalPerson(data);
            });         
    }

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    useEffect(() => {

        getLegalPerson();
    }, [])

    const onSubmit = event => {
        event.preventDefault();
    }


    return(
            <div>
            <Button variant="outlined" color="primary" onClick={handleOpen}>Изменить</Button>

            <Modal open={open}
            onClose={handleClose}>   
                  
                <div className={classes.class}>
                <h2>Редактировать Юр. лицо</h2><br />    
                    <form >
                        <input type="text" name="legal_person_id" hidden />
                        <div className="form1_div">ИНН</div><input type="text" required name="Legal_person_TIN" value={Legal_person_TIN} onChange={e=>(setLegalPersonTIN(e.target.value))} placeholder="Введите ИНН" className="form1_input" /> <br />
                        <div className="form1_div">КПП</div><input type="text" required name="Legal_person_CRS" value={Legal_person_CRS} onChange={e=>(setLegalPersonCRS(e.target.value))} placeholder="Введите КПП" className="form1_input" /> <br />
                        <div className="form1_div">ОГРН</div><input type="text" required name="Legal_person_MSRN" value={Legal_person_MSRN} onChange={e=>(setLegalPersonMSRN(e.target.value))} placeholder="Введите ОГРН" className="form1_input" /> <br />
                        <input id="create_button" type="submit" value="Применить" onClick={(e)=>{updateLegalPerson({legal_person_id, Legal_person_TIN, Legal_person_CRS, Legal_person_MSRN}); return false;}} />
                        <br />
                    </form>
                </div>
            </Modal>
            </div>
        )
}
export default EditedLegalPersonModel
