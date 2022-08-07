import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/fabradeTransaction";
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, ButtonGroup, Button } from "@mui/material";
import { withStyles } from "@mui/styles";
import FabradeTransactionForm from "./fabradeTransactionForm";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { useToasts } from "react-toast-notifications";

const styles = {
    root: {
        "& .MuiTableCell-head":{
            fontSize: "1.25rem"
        }
    },
    paper: {
        width: "100%",
        margin : '15px',
        padding : '15px'
    }}

const FabradeTransactions = ({classes,...props}) => {
    const [currentId, setCurrentId] = useState(0)

    useEffect(() => {
        props.fetchAllFabradeTransactions()
    }, [])

    const { addToast } = useToasts()

    const onDelete = id => {
        if (window.confirm('Are you sure you want to delete this record ?'))
            props.deleteFabradeTransaction(id,()=>addToast("Deleted successfully", { appearance: 'error' }))
    }
    
    return (
        <Paper className={classes.paper} elevation={10}>
            <Grid container>
                <Grid item xs={6}>
                    <FabradeTransactionForm {...({ currentId, setCurrentId })}/>
                </Grid>
                <Grid item xs={6}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>ID</TableCell>
                                    <TableCell>TYPE</TableCell>
                                    <TableCell>SIZE</TableCell>
                                    <TableCell>GENDER</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.fabradeTransactionList.map((record, index) => {
                                        return (<TableRow key={index} hover>
                                            <TableCell>{record.id}</TableCell>
                                            <TableCell>{record.dress_type}</TableCell>
                                            <TableCell>{record.size}</TableCell>
                                            <TableCell>{record.gender}</TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                    <Button>
                                                        <EditIcon color="primary" onClick={() => { setCurrentId(record.id) }}/>
                                                    </Button>
                                                    <Button>
                                                        <DeleteIcon color="error" onClick={() => onDelete(record.id)} />
                                                    </Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>)
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    );
}

const mapStateToProps = state => ({
    fabradeTransactionList: state.fabradeTransaction.list
})

const mapActionToProps = {
    fetchAllFabradeTransactions: actions.fetchAll,
    deleteFabradeTransaction: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(FabradeTransactions));