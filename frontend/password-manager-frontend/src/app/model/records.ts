export class Record{
    constructor(
        public id: number,
        public name: string,
        public password: string,
        public dateCreated: Date,
        public recordType: number
    ){}
}

export interface IRecords{
    id: number,
    name: string,
    password: string,
    dateCreated: Date,
    recordType: number;
}

export enum RecordType{
    Website = 0,
    Email = 1
}