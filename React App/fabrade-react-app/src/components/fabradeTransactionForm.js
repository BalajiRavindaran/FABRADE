import React, { useEffect } from "react";
import { Grid, Button, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText } from "@mui/material";
import { withStyles } from "@mui/styles";
import useForm from "./useForm";
import { connect } from "react-redux";
import * as actions from "../actions/fabradeTransaction";
import { useToasts } from "react-toast-notifications";


const styles = {
    root: {
        '& .MuiTextField-root': {
            margin: "8px",
            minWidth: 230,
        }
    },
    smMargin: {
        margin: "8px"
    }
}

const initialFieldValues = {
    contact_name: '',
    contact_no: '',
    dress_type: '',
    size: '',
    age: '',
    gender: '',
    color: ''
}

const FabradeTransactionForm = ({ classes, ...props }) => {

    const { addToast } = useToasts()

    const validate = (fieldValues = values) => {
        let temp = {...errors}
        if ("contact_name" in fieldValues)
            temp.contact_name = fieldValues.contact_name ? "" : "This field is required."
        if ("contact_no" in fieldValues)
            temp.contact_no = fieldValues.contact_no ? "" : "This field is required."
        if ("dress_type" in fieldValues)
            temp.dress_type = fieldValues.dress_type ? "" : "This field is required."
        if ("size" in fieldValues)
            temp.size = fieldValues.size ? "" : "This field is required."
        if ("age" in fieldValues)
            temp.age = fieldValues.age ? "" : "This field is required."
        if ("gender" in fieldValues)
            temp.gender = fieldValues.gender ? "" : "This field is required."
        if ("color" in fieldValues)
            temp.color = fieldValues.color ? "" : "This field is required."
        if ("contact_no" in fieldValues)
            temp.contact_no = (/^[6-9]\d{9}$/).test(fieldValues.contact_no) ? "" : "Contact Number is not valid"
        setErrors({
            ...temp
        })

        if (fieldValues === values)
            return Object.values(temp).every(x => x === "")
    }

    const {
        values,
        setValues,
        handleInputChange,
        errors,
        setErrors,
        resetForm
    } = useForm(initialFieldValues, validate, props.setCurrentId)

    const handleSubmit = e => {
        e.preventDefault()
        if (validate()) {
            const onSuccess = () => {
                resetForm()
                addToast("Submitted successfully", { appearance: 'success' })
            }

            if(props.currentId===0)
                props.createFabradeTransaction(values, onSuccess)
            else
                props.updateFabradeTransaction(props.currentId, values, onSuccess)
        }
    }

    useEffect(() => {
        if (props.currentId !== 0) {
            setValues({
                ...props.fabradeTransactionList.find(x => x.id === props.currentId)
            })
            setErrors({})
        }
    }, [props.currentId])

    return (
        <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
            <Grid container>
                <Grid item xs={6}>
                    <TextField name="contact_name" variant="outlined" label="Contact Name" value={values.contact_name} onChange={handleInputChange} {...(errors.contact_name && { error: true, helperText: errors.contact_name })} />
                    <TextField name="contact_no" variant="outlined" label="Contact Number" value={values.contact_no} onChange={handleInputChange} {...(errors.contact_no && { error: true, helperText: errors.contact_no })} />
                    <TextField name="dress_type" variant="outlined" label="Dress" value={values.dress_type} onChange={handleInputChange} {...(errors.dress_type && { error: true, helperText: errors.dress_type })} />
                    <TextField name="color" variant="outlined" label="Color" value={values.color} onChange={handleInputChange} {...(errors.color && { error: true, helperText: errors.color })} />
                </Grid>
                <Grid item xs={6}>
                    <FormControl sx={{ margin: "8px", minWidth: 230 }}
                        {...(errors.size && { error: true })}
                    >
                        <InputLabel>Size</InputLabel>
                        <Select name="size" value={values.size} label="Size" onChange={handleInputChange}>
                            <MenuItem value="">Select Size</MenuItem>
                            <MenuItem value="XS">XS</MenuItem>
                            <MenuItem value="S">S</MenuItem>
                            <MenuItem value="M">M</MenuItem>
                            <MenuItem value="L">L</MenuItem>
                            <MenuItem value="XL">XL</MenuItem>
                            <MenuItem value="XXL">XXL</MenuItem>
                        </Select>
                        {errors.size && <FormHelperText>{errors.size}</FormHelperText>}
                    </FormControl>

                    <FormControl sx={{ margin: "8px", minWidth: 230 }}
                        {...(errors.age && { error: true })}
                    >
                        <InputLabel>Age</InputLabel>
                        <Select name="age" value={values.age} label="Age" onChange={handleInputChange}>
                            <MenuItem value="">Select Age</MenuItem>
                            <MenuItem value="0 - 6">0 - 6</MenuItem>
                            <MenuItem value="7 - 13">7 - 13</MenuItem>
                            <MenuItem value="14 - 20">14 - 20</MenuItem>
                            <MenuItem value="21 - 25">21 - 25</MenuItem>
                            <MenuItem value="26 - 30">26 - 30</MenuItem>
                            <MenuItem value="31+">31+</MenuItem>
                        </Select>
                        {errors.age && <FormHelperText>{errors.age}</FormHelperText>}
                    </FormControl>

                    <FormControl sx={{ margin: "8px", minWidth: 230 }}
                        {...(errors.gender && { error: true })}
                    >
                        <InputLabel>Gender</InputLabel>
                        <Select name="gender" value={values.gender} label="Gender" onChange={handleInputChange}>
                            <MenuItem value="">Select Age</MenuItem>
                            <MenuItem value="M">M</MenuItem>
                            <MenuItem value="F">F</MenuItem>
                            <MenuItem value="Other">Other</MenuItem>
                        </Select>
                        {errors.gender && <FormHelperText>{errors.gender}</FormHelperText>}
                    </FormControl>

                    <div>
                        <Button variant="contained" size="large" color="success" type="submit" sx={{ margin: "14px" }}>Submit</Button>
                        <Button variant="contained" size="large" color="info" sx={{ margin: "14px" }} onClick={resetForm}>Reset</Button>
                    </div>
                </Grid>
            </Grid>
        </form>
    );
}

const mapStateToProps = state => ({
    fabradeTransactionList: state.fabradeTransaction.list
})

const mapActionToProps = {
    createFabradeTransaction: actions.create,
    updateFabradeTransaction: actions.update
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(FabradeTransactionForm));