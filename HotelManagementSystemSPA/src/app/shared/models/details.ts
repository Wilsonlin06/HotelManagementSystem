export interface roomDetails {
        roomNo: number;
        rtCode: number;
        status: boolean;
        roomTypes?: any;
        services?: any;
    }

export interface roomtypeDetails {
    id: number;
    rtDesc: string;
    rent: number;
}

export interface serviceDetails {
    id: number;
    roomId: number;
    sDesc: string;
    amount: number;
    serviceDate: Date;
    rooms?: any;
}

export interface customerDetails {
    id: number;
    roomNo: number;
    cName: string;
    address: string;
    phone: string;
    email: string;
    checkIn: Date;
    totalPersons: number;
    bookingDays: number;
    advance: number;
}
