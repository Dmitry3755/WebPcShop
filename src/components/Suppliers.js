import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Button, ButtonBase, Container, Modal } from '@material-ui/core';
import EditedLegalPersonModel from './EditedLegalPersonModel';
import EditPhysicalPersonModel from './EditPhysicalPersonModel';

const useStyles = makeStyles((theme) => ({
    table: {
        position: "static",
        width: "94%",
        overflow: "auto",
        marginTop: "1%",
        marginLeft: "3%",
        marginRight: "3%",
        borderCollapse: "collapse",
    },
    tableTrTd: {    
        borderTop: "2px solid #ccc",
        borderLeft: "2px solid #ccc",
        borderRight: "2px solid #ccc",
        borderBottom: "2px solid #ccc",
        textAlign: "center",
      },
      tableTh: {
          position: "static",
          fontSize: "130%",
          textAlign: "center",
          borderTop: "2px solid #ccc",
          borderLeft: "2px solid #ccc",
          borderRight: "2px solid #ccc",
      },
      captionTable: {
          fontSize: "150%",
          marginTop: "1%",
          marginBottom: "1%",
          textAlign: "center",
          fontWeight: "bold",
      },
      select: {
        marginLeft: "45%",
        marginRight: "45%",
        marginTop: "1%",
    },
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
}));

const Suppliers = () => {
    const [legalPersons, setLegalPerson] = useState([]);
    const [legal_person_id, setLegalPersonId] = useState([]);
    const [Legal_person_TIN, setLegalPersonTIN] = useState([]);
    const [Legal_person_CRS, setLegalPersonCRS] = useState([]);
    const [Legal_person_MSRN, setLegalPersonMSRN] = useState([]);

    const [physicalPersons, setPhysicalPerson] = useState([]);
    const [physical_person_id, setPhysicalPersonsId] = useState([]);
    const [physical_person_name, setPhysicalPersonsName] = useState([]);
    const [physical_person_pasport_number, setLegalPersonPasportNumber] = useState([]);
    const [physical_person_TIN, setPhysicalPersonsTIN] = useState([]);

    const [open, setAdd] = React.useState(false);
    const classes = useStyles();

    const handleCreate = () => {
        setAdd(true);
    };
    const handleClose = () => {
        setAdd(false);
    };


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
    
    const getPhysicalPerson = () => {
        fetch("http://localhost:36964/api/PhysicalPerson/", {
            headers : {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json',
            },
            credentials: 'include'
        })
            .then(response => response.json())
            .then(data => {
                setPhysicalPerson(data);
            });
            
    }

    const createLegalPerson = (legalPerson) =>
    {
        fetch("http://localhost:36964/api/LegalPerson/",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            credentials: 'include',
            body:JSON.stringify({

                Legal_person_TIN: legalPerson.Legal_person_TIN,
                Legal_person_CRS: legalPerson.Legal_person_CRS,
                Legal_person_MSRN: legalPerson.Legal_person_MSRN,
            })
        })
        .then(response=>response.json());
    }

    const createPhysicalPersonsn = (physicalPerson) =>
    {
        fetch("http://localhost:36964/api/PhysicalPerson/",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            credentials: 'include',
            body:JSON.stringify({

                physical_person_name: physicalPerson.physical_person_name,
                physical_person_pasport_number: physicalPerson.physical_person_pasport_number,
                physical_person_TIN: physicalPerson.physical_person_TIN,
            })
        })
        .then(response=>response.json());
    }

    const deleteLegalPerson = (legal_person_id) =>
    {
        fetch("http://localhost:36964/api/LegalPerson/"+legal_person_id, {
            method : 'DELETE',
            headers : {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json',
            },
            credentials: 'include'
        });        
    }
    const deletePhysicalPerson = (physical_person_id) =>
    {
        fetch("http://localhost:36964/api/PhysicalPerson/"+physical_person_id, {
            method : 'DELETE',
            headers : {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json',
            },
            credentials: 'include'
        });        
    }


    function valuePerson(value){
        if(value === "physicalPersons") {
            document.getElementById("legalPersonTable").style.display = 'none';
            document.getElementById("LegalPersonButton").style.display = 'none';
            document.getElementById("physicalPersonTable").style.display = 'table';
            document.getElementById("PhysicalPersonButton").style.display = 'block';
            
        }
        else {
            document.getElementById("physicalPersonTable").style.display = 'none';
            document.getElementById("PhysicalPersonButton").style.display = 'none';
            document.getElementById("legalPersonTable").style.display = 'table';
            document.getElementById("LegalPersonButton").style.display = 'block';      
        }
    }

    useEffect(() => {

        getLegalPerson();
    }, [])  
    useEffect(() => {

        getPhysicalPerson();
    }, []) 

    const onSubmit = event => {
        event.preventDefault();
    }

    return (
        <div>
            <div>
            <select className={classes.select} onChange={e=>(valuePerson(e.target.value))}>
                <option value= "legalPersons">Юридическое лицо</option>
                <option value= "physicalPersons">Физическое лицо</option>
            </select> <br />
            </div>

            <div id = "LegalPersonButton">
            <Button variant="outlined" color="primary" style={{position: "absolute" , left: "89%", top: "10%"}} onClick={handleCreate}>Добавить</Button>
            <Modal open={open}
            onClose={handleClose}>       

                <div className={classes.class} >
                <h2>Добавить поставщика(Юр. лицо)</h2><br />    
                    <form>
                        <div className="form1_div">ИНН</div><input type="text" required name="Legal_person_TIN" onChange={e=>(setLegalPersonTIN(e.target.value))} placeholder="Введите ИНН" className="form1_input" /> <br />
                        <div className="form1_div">КПП</div><input type="text" required name="Legal_person_CRS" onChange={e=>(setLegalPersonCRS(e.target.value))} placeholder="Введите КПП" className="form1_input" /> <br />
                        <div className="form1_div">ОГРН</div><input type="text" required name="Legal_person_MSRN" onChange={e=>(setLegalPersonMSRN(e.target.value))} placeholder="Введите ОГРН" className="form1_input" /> <br />
                        <input id="createButton" type="submit" value="Применить" onClick={(e)=>{createLegalPerson({legal_person_id, Legal_person_TIN, Legal_person_CRS, Legal_person_MSRN}); return false;}} />
                    </form>
                </div>
            </Modal>
            </div>
            <div id = "PhysicalPersonButton" style={{display: 'none'}}>
            <Button variant="outlined" color="primary" style={{position: "absolute" , left: "89%", top: "10%"}} onClick={handleCreate}>Добавить</Button>
            <Modal open={open}
            onClose={handleClose}>       

                <div className={classes.class} >
                <h2>Добавить поставщика(Физ. лицо)</h2><br />    
                    <form onSubmit={onSubmit}>
                        <div className="form1_div">ФИО</div><input type="text" required name="physical_person_name" onChange={e=>(setPhysicalPersonsName(e.target.value))} placeholder="Введите ФИО" className="form1_input" /> <br />
                        <div className="form1_div">Серия, номер паспорта</div><input type="text" required name="physical_person_pasport_number" onChange={e=>(setLegalPersonPasportNumber(e.target.value))} placeholder="Введите КПП" className="form1_input" /> <br />
                        <div className="form1_div">ИНН</div><input type="text" required name="physical_person_TIN" onChange={e=>(setPhysicalPersonsTIN(e.target.value))} placeholder="Введите ОГРН" className="form1_input" /> <br />
                        <input id="createButton" type="submit" value="Применить" onClick={(e)=>{createPhysicalPersonsn({physical_person_id, physical_person_name, physical_person_pasport_number, physical_person_TIN}); return false;}} />
                    </form>
                </div>
            </Modal>
            </div>

            <form>
            <table className={classes.table} id="legalPersonTable">
                 <caption className={classes.captionTable}>Список поставщиков</caption>
                <thead>
                    <tr>
                        <th className={classes.tableTh}>ИНН</th>
                        <th className={classes.tableTh}>КПП</th>
                        <th className={classes.tableTh}>ОГРН</th>
                        <th className={classes.tableTh}>Редактирование</th>
                    </tr>
                </thead>
                <tbody>
                    {legalPersons.map(legalPerson => {
                        return (
                            <tr key={legalPerson.Id}>
                                <td className={classes.tableTrTd}>{legalPerson.Legal_person_TIN}</td>
                                <td className={classes.tableTrTd}>{legalPerson.Legal_person_CRS}</td>
                                <td className={classes.tableTrTd}>{legalPerson.Legal_person_MSRN}</td>
                                <td className={classes.tableTrTd}>
                                <div>
                                    <ButtonBase style={{margin: "3%"}}>
                                        <EditedLegalPersonModel EditedLegalPerson={legalPerson}></EditedLegalPersonModel>
                                    </ButtonBase>
                                    <Button style={{margin: "3%"}} variant="outlined" color="primary" onClick={(e)=>deleteLegalPerson(legalPerson.legal_person_id)}>Удалить</Button>
                                </div>
                            </td> 
                            </tr>
                            )})}
                </tbody>               
                </table> 
                <table className={classes.table} id="physicalPersonTable" style={{display: 'none'}}>
                        <caption className={classes.captionTable}>Список поставщиков</caption>
                            <thead>
                                <tr>
                                    <th className={classes.tableTh}>ФИО</th>
                                    <th className={classes.tableTh}>Номер паспорта</th>
                                    <th className={classes.tableTh}>ИНН</th>
                                    <th className={classes.tableTh}>Редактирование</th>
                                </tr>
                            </thead>
                            <tbody>
                                {physicalPersons.map(physicalPerson => {
                                    return (
                                        <tr key={physicalPerson.Id}>
                                        <td className={classes.tableTrTd} key={physicalPerson.physical_person_name}>{physicalPerson.physical_person_name}</td>
                                        <td className={classes.tableTrTd} key={physicalPerson.physical_person_pasport_number}>{physicalPerson.physical_person_pasport_number}</td>
                                        <td className={classes.tableTrTd} key={physicalPerson.physical_person_TIN}>{physicalPerson.physical_person_TIN}</td>
                                        <td className={classes.tableTrTd}>
                                            <div>
                                                <ButtonBase style={{margin: "3%"}}>
                                                    <EditPhysicalPersonModel EditedPhysicalPersons={physicalPerson}></EditPhysicalPersonModel>
                                                </ButtonBase>
                                                <Button style={{margin: "3%"}} variant="outlined" color="primary" onClick={(e)=>deletePhysicalPerson(physicalPerson.physical_person_id)}>Удалить</Button>
                                            </div>
                                        </td> 
                                        </tr>
                                    )
                                }
                                )}
                            </tbody>
                    </table>                       
                </form>
        </div>
    ); 
}
export default Suppliers