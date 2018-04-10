import { Injectable } from '@angular/core';

export type InternalStateType = {
    [key: string]: any
};

@Injectable()
export class AppState {
    _state: InternalStateType = {};

    constructor() { }

    get state() {
        return this._state;
    }

    get(prop?: any) {
        return this._state.hasOwnProperty(prop) ? this._state[prop] :
            undefined;
    }

    set(prop: string, value: any) {
        return this._state[prop] = value;
    }

}
