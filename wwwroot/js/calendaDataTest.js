


var calendarData =
    [
        { title: 'Event A', start: '2024-09-02T08:00:00', end: '2024-09-02T10:00:00' },
        { title: 'Event B', start: '2024-09-02T08:00:00', end: '2024-09-02T09:00:00' },
        { title: 'Event C', start: '2024-09-02T09:00:00', end: '2024-09-02T11:00:00' },
        { title: 'Event D', start: '2024-09-02T10:00:00', end: '2024-09-02T13:00:00' },
        { title: 'Event E', start: '2024-09-02T12:00:00', end: '2024-09-02T14:00:00' },
        { title: 'Event F', start: '2024-09-02T13:00:00', end: '2024-09-02T16:00:00' },
        { title: 'Event G', start: '2024-09-02T15:00:00', end: '2024-09-02T16:00:00' },
        { title: 'Event H', start: '2024-09-02T15:30:00', end: '2024-09-02T17:30:00' },

        { title: 'Event I', start: '2024-09-03T09:00:00', end: '2024-09-03T10:00:00' },
        { title: 'Event J', start: '2024-09-03T09:00:00', end: '2024-09-03T10:00:00' }, // Exact overlap
        { title: 'Event K', start: '2024-09-03T10:00:00', end: '2024-09-03T12:00:00' },
        { title: 'Event L', start: '2024-09-03T10:30:00', end: '2024-09-03T13:30:00' }, // Overlap
        { title: 'Event M', start: '2024-09-03T11:00:00', end: '2024-09-03T12:00:00' },
        { title: 'Event N', start: '2024-09-03T12:30:00', end: '2024-09-03T15:00:00' },
        { title: 'Event O', start: '2024-09-03T14:00:00', end: '2024-09-03T17:00:00' },
        { title: 'Event P', start: '2024-09-03T16:00:00', end: '2024-09-03T17:00:00' },
        { title: 'Event Q', start: '2024-09-03T16:00:00', end: '2024-09-03T18:00:00' }, // Overlapping start

        { title: 'Event R', start: '2024-09-04T08:30:00', end: '2024-09-04T09:30:00' },
        { title: 'Event S', start: '2024-09-04T09:00:00', end: '2024-09-04T10:00:00' }, // Overlap
        { title: 'Event T', start: '2024-09-04T09:30:00', end: '2024-09-04T11:30:00' },
        { title: 'Event U', start: '2024-09-04T10:00:00', end: '2024-09-04T12:00:00' },
        { title: 'Event V', start: '2024-09-04T11:00:00', end: '2024-09-04T12:00:00' },
        { title: 'Event W', start: '2024-09-04T12:30:00', end: '2024-09-04T14:00:00' },
        { title: 'Event X', start: '2024-09-04T14:00:00', end: '2024-09-04T15:00:00' },
        { title: 'Event Y', start: '2024-09-04T14:00:00', end: '2024-09-04T17:00:00' }, // Overlap start
        { title: 'Event Z', start: '2024-09-04T16:00:00', end: '2024-09-04T18:00:00' },

        { title: 'Event AA', start: '2024-09-05T08:00:00', end: '2024-09-05T09:00:00' },
        { title: 'Event AB', start: '2024-09-05T08:30:00', end: '2024-09-05T10:00:00' }, // Overlap
        { title: 'Event AC', start: '2024-09-05T09:30:00', end: '2024-09-05T11:30:00' },
        { title: 'Event AD', start: '2024-09-05T10:00:00', end: '2024-09-05T11:00:00' },
        { title: 'Event AE', start: '2024-09-05T11:30:00', end: '2024-09-05T13:30:00' },
        { title: 'Event AF', start: '2024-09-05T12:00:00', end: '2024-09-05T13:00:00' },
        { title: 'Event AG', start: '2024-09-05T13:00:00', end: '2024-09-05T15:00:00' },
        { title: 'Event AH', start: '2024-09-05T15:00:00', end: '2024-09-05T17:00:00' },
        { title: 'Event AI', start: '2024-09-05T16:00:00', end: '2024-09-05T17:30:00' },

        { title: 'Event AJ', start: '2024-09-06T09:00:00', end: '2024-09-06T11:00:00' },
        { title: 'Event AK', start: '2024-09-06T09:30:00', end: '2024-09-06T12:00:00' }, // Overlap
        { title: 'Event AL', start: '2024-09-06T10:00:00', end: '2024-09-06T11:30:00' },
        { title: 'Event AM', start: '2024-09-06T11:00:00', end: '2024-09-06T12:00:00' },
        { title: 'Event AN', start: '2024-09-06T12:30:00', end: '2024-09-06T14:30:00' },
        { title: 'Event AO', start: '2024-09-06T13:00:00', end: '2024-09-06T14:00:00' },
        { title: 'Event AP', start: '2024-09-06T14:30:00', end: '2024-09-06T16:30:00' },
        { title: 'Event AQ', start: '2024-09-06T15:00:00', end: '2024-09-06T17:00:00' },
        { title: 'Event AR', start: '2024-09-06T16:00:00', end: '2024-09-06T17:30:00' },

        // More events for mid-September
        { title: 'Event AS', start: '2024-09-09T09:00:00', end: '2024-09-09T10:00:00' },
        { title: 'Event AT', start: '2024-09-09T10:00:00', end: '2024-09-09T11:00:00' },
        { title: 'Event AU', start: '2024-09-09T10:30:00', end: '2024-09-09T12:30:00' }, // Overlap
        { title: 'Event AV', start: '2024-09-09T11:00:00', end: '2024-09-09T13:00:00' },
        { title: 'Event AW', start: '2024-09-09T12:00:00', end: '2024-09-09T14:00:00' },
        { title: 'Event AX', start: '2024-09-09T13:00:00', end: '2024-09-09T14:00:00' },
        { title: 'Event AY', start: '2024-09-09T14:00:00', end: '2024-09-09T16:00:00' },
        { title: 'Event AZ', start: '2024-09-09T15:00:00', end: '2024-09-09T17:00:00' },
        { title: 'Event BA', start: '2024-09-09T16:00:00', end: '2024-09-09T17:30:00' },

        { title: 'Event BB', start: '2024-09-10T09:00:00', end: '2024-09-10T11:00:00' },
        { title: 'Event BC', start: '2024-09-10T10:00:00', end: '2024-09-10T12:00:00' },
        { title: 'Event BD', start: '2024-09-10T10:30:00', end: '2024-09-10T12:30:00' }, // Overlap
        { title: 'Event BE', start: '2024-09-10T11:00:00', end: '2024-09-10T13:00:00' },
        { title: 'Event BF', start: '2024-09-10T12:00:00', end: '2024-09-10T14:00:00' },
        { title: 'Event BG', start: '2024-09-10T13:00:00', end: '2024-09-10T14:00:00' },
        { title: 'Event BH', start: '2024-09-10T14:00:00', end: '2024-09-10T16:00:00' },
        { title: 'Event BI', start: '2024-09-10T15:00:00', end: '2024-09-10T17:00:00' },
        { title: 'Event BJ', start: '2024-09-10T16:00:00', end: '2024-09-10T17:30:00' },

        { title: 'Event BB', start: '2024-09-10T09:00:00', end: '2024-09-10T11:00:00' },
        { title: 'Event BC', start: '2024-09-10T10:00:00', end: '2024-09-10T12:00:00' },
        { title: 'Event BD', start: '2024-09-10T10:30:00', end: '2024-09-10T12:30:00' }, // Overlap
        { title: 'Event BE', start: '2024-09-10T11:00:00', end: '2024-09-10T13:00:00' },
        { title: 'Event BF', start: '2024-09-10T12:00:00', end: '2024-09-10T14:00:00' },
        { title: 'Event BG', start: '2024-09-10T13:00:00', end: '2024-09-10T14:00:00' },
        { title: 'Event BH', start: '2024-09-10T14:00:00', end: '2024-09-10T16:00:00' },
        { title: 'Event BI', start: '2024-09-10T15:00:00', end: '2024-09-10T17:00:00' },
        { title: 'Event BJ', start: '2024-09-10T16:00:00', end: '2024-09-10T17:30:00' },

        // Continuing from September 11th
        { title: 'Event BK', start: '2024-09-11T09:00:00', end: '2024-09-11T11:00:00' },
        { title: 'Event BL', start: '2024-09-11T09:30:00', end: '2024-09-11T11:30:00' },
        { title: 'Event BM', start: '2024-09-11T10:00:00', end: '2024-09-11T12:00:00' },
        { title: 'Event BN', start: '2024-09-11T10:30:00', end: '2024-09-11T12:30:00' },
        { title: 'Event BO', start: '2024-09-11T11:00:00', end: '2024-09-11T12:00:00' },
        { title: 'Event BP', start: '2024-09-11T12:30:00', end: '2024-09-11T14:30:00' },
        { title: 'Event BQ', start: '2024-09-11T13:00:00', end: '2024-09-11T14:00:00' },
        { title: 'Event BR', start: '2024-09-11T14:00:00', end: '2024-09-11T16:00:00' },
        { title: 'Event BS', start: '2024-09-11T15:00:00', end: '2024-09-11T17:00:00' },
        { title: 'Event BT', start: '2024-09-11T16:00:00', end: '2024-09-11T18:00:00' },

        // September 12
        { title: 'Event BU', start: '2024-09-12T08:00:00', end: '2024-09-12T10:00:00' },
        { title: 'Event BV', start: '2024-09-12T09:00:00', end: '2024-09-12T11:00:00' },
        { title: 'Event BW', start: '2024-09-12T09:30:00', end: '2024-09-12T12:00:00' },
        { title: 'Event BX', start: '2024-09-12T10:00:00', end: '2024-09-12T12:00:00' },
        { title: 'Event BY', start: '2024-09-12T11:00:00', end: '2024-09-12T13:00:00' },
        { title: 'Event BZ', start: '2024-09-12T12:00:00', end: '2024-09-12T14:00:00' },
        { title: 'Event CA', start: '2024-09-12T13:00:00', end: '2024-09-12T15:00:00' },
        { title: 'Event CB', start: '2024-09-12T14:00:00', end: '2024-09-12T16:00:00' },
        { title: 'Event CC', start: '2024-09-12T15:00:00', end: '2024-09-12T17:00:00' },
        { title: 'Event CD', start: '2024-09-12T16:00:00', end: '2024-09-12T18:00:00' },

        // September 24
        { title: 'Event CE', start: '2024-09-24T09:00:00', end: '2024-09-24T10:00:00' },
        { title: 'Event CF', start: '2024-09-24T09:00:00', end: '2024-09-25T11:00:00' }, // Overlap
        { title: 'Event CG', start: '2024-09-24T10:00:00', end: '2024-09-27T11:30:00' },
        { title: 'Event CH', start: '2024-09-24T11:00:00', end: '2024-09-24T12:00:00' },
        { title: 'Event CI', start: '2024-09-24T12:00:00', end: '2024-09-30T13:00:00' },
        { title: 'Event CJ', start: '2024-09-24T12:30:00', end: '2024-11-24T14:30:00' },
        { title: 'Event CK', start: '2024-09-24T14:00:00', end: '2024-12-24T15:30:00' },
        { title: 'Event CL', start: '2024-09-24T14:30:00', end: '2024-09-24T16:30:00' },
        { title: 'Event CM', start: '2024-09-24T15:00:00', end: '2024-09-29T17:00:00' },
        { title: 'Event CN', start: '2024-09-24T16:00:00', end: '2024-10-14T18:00:00' },

        // September 25
        { title: 'Event CO', start: '2024-09-25T08:30:00', end: '2024-09-26T10:00:00' },
        { title: 'Event CP', start: '2024-09-25T09:00:00', end: '2024-09-27T10:00:00' },
        { title: 'Event CQ', start: '2024-09-25T09:30:00', end: '2024-10-16T11:00:00' },
        { title: 'Event CR', start: '2024-09-25T10:00:00', end: '2024-09-25T12:00:00' },
        { title: 'Event CS', start: '2024-09-25T10:30:00', end: '2024-09-25T12:30:00' },
        { title: 'Event CT', start: '2024-09-25T11:00:00', end: '2024-09-29T12:00:00' },
        { title: 'Event CU', start: '2024-09-25T12:30:00', end: '2024-09-25T14:00:00' },
        { title: 'Event CV', start: '2024-09-25T13:00:00', end: '2024-09-25T15:00:00' },
        { title: 'Event CW', start: '2024-09-25T14:00:00', end: '2024-09-25T16:00:00' },
        { title: 'Event CX', start: '2024-09-25T15:00:00', end: '2024-09-27T17:00:00' },

        // September 26
        { title: 'Event CY', start: '2024-09-26T08:30:00', end: '2024-09-26T09:30:00' },
        { title: 'Event CZ', start: '2024-09-26T09:00:00', end: '2024-09-26T10:00:00' },
        { title: 'Event DA', start: '2024-09-26T09:30:00', end: '2024-09-26T11:30:00' },
        { title: 'Event DB', start: '2024-09-26T10:00:00', end: '2024-09-26T12:00:00' },
        { title: 'Event DC', start: '2024-09-26T10:30:00', end: '2024-09-26T12:30:00' },
        { title: 'Event DD', start: '2024-09-26T11:00:00', end: '2024-09-26T13:00:00' },
        { title: 'Event DE', start: '2024-09-26T12:00:00', end: '2024-09-26T14:00:00' },
        { title: 'Event DF', start: '2024-09-26T13:00:00', end: '2024-10-06T14:30:00' },
        { title: 'Event DG', start: '2024-09-26T14:00:00', end: '2024-10-18T16:00:00' },
        { title: 'Event DH', start: '2024-09-26T15:00:00', end: '2024-10-15T17:00:00' },

        // September 27
        { title: 'Event DI', start: '2024-09-27T09:00:00', end: '2024-09-27T10:00:00' },
        { title: 'Event DJ', start: '2024-09-27T09:30:00', end: '2024-09-27T11:30:00' },
        { title: 'Event DK', start: '2024-09-27T10:00:00', end: '2024-09-27T12:00:00' },
        { title: 'Event DL', start: '2024-09-27T11:00:00', end: '2024-09-27T13:00:00' },
        { title: 'Event DM', start: '2024-09-27T12:00:00', end: '2024-09-29T14:00:00' },
        { title: 'Event DN', start: '2024-09-27T12:30:00', end: '2024-09-30T14:30:00' },
        { title: 'Event DO', start: '2024-09-27T13:00:00', end: '2024-09-27T15:00:00' },
        { title: 'Event DP', start: '2024-09-27T14:00:00', end: '2024-09-27T16:00:00' },
        { title: 'Event DQ', start: '2024-09-27T15:00:00', end: '2024-09-27T17:00:00' },
        { title: 'Event DR', start: '2024-09-27T16:00:00', end: '2024-09-30T18:00:00' },

    ];
