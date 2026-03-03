import { useState, useEffect } from 'react';
import axios from 'axios';

export const useUserTransactions = () => {
    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const fetchTransactions = async () => {
        setLoading(true);
        try {
            const response = await axios.get('/api/UserTransaction');
            console.log(response.data)
            setTransactions(response.data);
        } catch (err) {
            setError(err.message);
            console.error('Error fetching user transactions:', err);
        } finally {
            setLoading(false);
        }
    };

    //const addTransaction = async (transaction) => {
    //    try {
    //        const response = await axios.post('/api/UserTransaction', transaction);
    //        setTransactions(prev => [...prev, response.data]);
    //    catch (err) {
    //            setError(err.message);
    //        }
    //    }

    


    useEffect(() => {
        fetchTransactions();
    }, []);

    const refresh = () => {
        fetchTransactions();
    };

    return {
        transactions,
        loading,
        error,
        refresh,
        //addTransaction
    };
};

//export default useUserTransactions;