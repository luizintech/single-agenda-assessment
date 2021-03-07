export enum Gender {
    Male = 1,
    Female = 2,
    NonBinary = 3
}

export module Gender {
    export function toDisplayName(value: Gender): string {
        switch (value) {
        case Gender.Male:
            return 'Male';
        case Gender.Female:
            return 'Female';
        case Gender.NonBinary:
            return 'NonBinary';
        default:
            return null;
        }
    }
}