import { Component } from "react";
import {Modal, Button} from '@material-ui/core'
import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';

function updateProducts(products) {

    console.log(products);
    fetch("http://localhost:36964/api/Products/"+products.product_id,
    {
        method:'PUT',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        body:JSON.stringify({

            product_id: products.product_id,
            product_name: products.product_name,
            technical_specifications: products.technical_specifications,
            count_of_products: products.count_of_products,
            product_price: products.product_price,
            discount: products.discount,
            category_FK: products.category_FK,
        })
    })
    .then(response=>{response.json()})
    //.then(result=>alert(result));
}

const EditPoductsModal = ({EditedProducts}) => {
    
    const [categories, setCategories] = useState([]);
    const [product_id, SetProductId] = useState(EditedProducts.product_id);
    const [product_name, SetProductName] = useState(EditedProducts.product_name);
    const [technical_specifications, SetTechnicalSpecifications] = useState(EditedProducts.technical_specifications);
    const [count_of_products, SetCountOfProducts] = useState(EditedProducts.count_of_products);
    const [product_price, SetProductPrice] = useState(EditedProducts.product_price);
    const [discount, SetDiscount] = useState(EditedProducts.discount);
    const [category_FK, SetCategoryFK] = useState(EditedProducts.category_FK);

    const getCategories = () => {
        fetch("http://localhost:36964/api/Categories/")
            .then(response => response.json())
            .then(data => {
                setCategories(data);
            });
    }

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

    const onSubmit = event => {
        event.preventDefault();
    }

    const classes = useStyles();
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    useEffect(() => {

        getCategories();
    }, [])


    return(
            <div>
            <Button variant="outlined" color="primary" onClick={handleOpen}>Изменить</Button>

            <Modal open={open}
            onClose={handleClose}>   
                  
                <div className={classes.class}>
                <h2>Редактировать продукт</h2><br />    
                    <form >
                        <input type="text" name="product_id" hidden />
                        <div className="form1_div">Название</div><input type="text" required name="product_name" value={product_name} onChange={e=>(SetProductName(e.target.value))} placeholder="Введите название" className="form1_input" /> <br />
                        <div className="form1_div">Характеристика</div><input type="text" required name="technical_specifications" value={technical_specifications} onChange={e=>(SetTechnicalSpecifications(e.target.value))} placeholder="Введите характеристики" className="form1_input" /><br />
                        <div className="form1_div">Количество</div><input type="text" required name="count_of_products" value={count_of_products} onChange={e=>(SetCountOfProducts(e.target.value))} placeholder="Введите количество продукта" className="form1_input" /><br />
                        <div className="form1_div">Цена</div><input type="text" required name="product_price" value={product_price} onChange={e=>(SetProductPrice(e.target.value))} placeholder="Введите цену" className="form1_input" /><br />
                        <div className="form1_div">Скидка</div><input type="text" required name="discount" value={discount} onChange={e=>(SetDiscount(e.target.value))} placeholder="Укажите скидку" className="form1_input" /><br />
                        <div className="form1_div">Категория</div>
                        <select name="category" value={category_FK} onChange={e=>(SetCategoryFK(e.target.value))}>
                        {categories.map((category) =>
                            <option name="category_FK" value={category.category_id}>{category.category_name}</option>
                        )}
                        </select> <br />
                        <input id="create_button" type="submit" value="Применить" onClick={(e)=>{updateProducts({product_id, product_name, technical_specifications, count_of_products, product_price, discount, category_FK}); return false;}} />
                        <br />
                    </form>
                </div>
            </Modal>
            </div>
        )
}
export default EditPoductsModal
