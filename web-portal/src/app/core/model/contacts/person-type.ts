export enum PersonType {
    Natural = 1,
    Legal = 2
}

export module PersonType {
    export function toDisplayName(value: PersonType): string {
        switch (value) {
        case PersonType.Natural:
            return 'Natural';
        case PersonType.Legal:
            return 'Legal';
        default:
            return null;
        }
    }
}